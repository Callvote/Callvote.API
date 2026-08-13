using System;
using System.Collections.Concurrent;

namespace Callvote.API.Features.Generic
{
    /// <summary>
    /// Represents the class for managing and creating pools.
    /// </summary>
    /// <typeparam name="T">The object to be pooled.</typeparam>
    public class Pool<T> : IDisposable
    {
        private readonly ConcurrentBag<T> pool = new ConcurrentBag<T>();

        private readonly Func<T> factory;

        private bool isDisposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="Pool{T}"/> class.
        /// </summary>
        /// <param name="factory">The item factory.</param>
        /// <param name="preload">The amount of items to preload.</param>
        internal Pool(Func<T> factory, int preload = 0)
        {
            this.factory = factory;
            this.PreloadItems(preload);
        }

        /// <summary>
        /// Fetches an item from the pool.
        /// </summary>
        /// <returns>The item to be used.</returns>
        public virtual T Fetch() => this.pool.TryTake(out T item) ? item : this.factory();

        /// <summary>
        /// Disposes the pool.
        /// </summary>
        public void Dispose()
        {
            if (this.isDisposed)
            {
                return;
            }

            this.isDisposed = true;

            if (!typeof(IDisposable).IsAssignableFrom(typeof(T)))
            {
                return;
            }

            lock (this.pool)
            {
                while (this.pool.Count > 0)
                {
                    IDisposable disposable = (IDisposable)this.Fetch();
                    disposable.Dispose();
                }
            }
        }

        /// <summary>
        /// Stores an item into the pool.
        /// </summary>
        /// <param name="item">The item to be stored.</param>
        protected virtual void Store(T item) => this.pool.Add(item);

        /// <summary>
        /// Pre-allocates a specific amount of items into the pool.
        /// </summary>
        /// <param name="amount">The amount to be pre-allocated.</param>
        private void PreloadItems(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                this.Store(this.factory());
            }
        }
    }
}