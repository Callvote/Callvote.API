using System;

namespace Callvote.API.Features.Votes
{
    /// <summary>
    /// Represents the type that manages and creates the <see cref="UserIdentifier"/>.
    /// </summary>
    public record UserIdentifier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserIdentifier"/> class.
        /// </summary>
        /// <param name="userId"><see cref="UserId"/>.</param>
        /// <param name="name"><see cref="Username"/>.</param>
        /// <param name="uniqueId"><see cref="UniqueUserId"/>.</param>
        public UserIdentifier(int userId, string name, string uniqueId)
        {
            this.UserId = userId;
            this.Username = name;
            this.UniqueUserId = uniqueId;
        }

        /// <summary>
        /// Gets the player's id.
        /// </summary>
        public int UserId { get; }

        /// <summary>
        /// Gets the player's name.
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// Gets the player's unique id.
        /// </summary>
        /// <remarks>This can be a steamid, or any type of unique identifier for that specific player.</remarks>
        public string UniqueUserId { get; }

#if !BAREBONES
        /// <summary>
        /// Implicitly converts a ReferenceHub instance to a UserIdentifier instance, enabling seamless use of user
        /// identification data where a UserIdentifier is required.
        /// </summary>
        /// <param name="referenceHub">The ReferenceHub instance containing the player's identification information to be converted.</param>
        public static implicit operator UserIdentifier(ReferenceHub referenceHub) => new(referenceHub.PlayerId, referenceHub.nicknameSync.MyNick, referenceHub.authManager.UserId);
#endif

        /// <inheritdoc/>
        public override int GetHashCode() => this.UniqueUserId?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public virtual bool Equals(UserIdentifier other) => other is not null && string.Equals(this.UniqueUserId, other.UniqueUserId, StringComparison.Ordinal);
    }
}