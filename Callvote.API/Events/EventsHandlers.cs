using System;
using System.Diagnostics;
using Callvote.API.Delegates;
using Callvote.API.Events.EventArgs;

namespace Callvote.API.Events
{
    /// <summary>
    /// Vote related events handlers.
    /// </summary>
    public static class EventsHandlers
    {
        /// <summary>
        /// Invoked after calling a vote, whether it started.
        /// </summary>
        /// <remarks>
        /// Check <see cref="VoteCalledEventArgs.Status"/> before assuming there is a running vote.
        /// </remarks>
        public static event CustomEventHandler<VoteCalledEventArgs> CalledVote;

        /// <summary>
        /// Invoked before calling a vote.
        /// </summary>
        public static event CustomEventHandler<CallingVoteEventArgs> CallingVote;

        /// <summary>
        /// Invoked after a player votes.
        /// </summary>
        public static event CustomEventHandler<UserVotedEventArgs> UserVoted;

        /// <summary>
        /// Invoked before a player votes.
        /// </summary>
        public static event CustomEventHandler<UserVotingEventArgs> UserVoting;

        /// <summary>
        /// Invoked after a vote ends.
        /// </summary>
        public static event CustomEventHandler<VoteEndedEventArgs> VoteEnded;

        /// <summary>
        /// Invoked before a vote ends.
        /// </summary>
        /// <remarks>
        /// Denying this only suppresses the results message and the <see cref="Features.Votes.Vote.Callback"/>, the vote is still stopped.
        /// </remarks>
        public static event CustomEventHandler<VoteEndingEventArgs> VoteEnding;

        /// <summary>
        /// Called after calling a vote.
        /// </summary>
        /// <param name="ev">The <see cref="VoteCalledEventArgs"/> instance.</param>
        public static void OnCalledVote(VoteCalledEventArgs ev) => CalledVote?.InvokeEvent(ev);

        /// <summary>
        /// Called before calling a vote.
        /// </summary>
        /// <param name="ev">The <see cref="VoteCalledEventArgs"/> instance.</param>
        public static void OnCallingVote(CallingVoteEventArgs ev) => CallingVote?.InvokeEvent(ev);

        /// <summary>
        /// Called after a player votes.
        /// </summary>
        /// <param name="ev">The <see cref="UserVotingEventArgs"/> instance.</param>
        public static void OnVoted(UserVotedEventArgs ev) => UserVoted?.InvokeEvent(ev);

        /// <summary>
        /// Called before a player votes.
        /// </summary>
        /// <param name="ev">The <see cref="UserVotingEventArgs"/> instance.</param>
        public static void OnVoting(UserVotingEventArgs ev) => UserVoting?.InvokeEvent(ev);

        /// <summary>
        /// Called after a vote ends.
        /// </summary>
        /// <param name="ev">The <see cref="VoteEndedEventArgs"/> instance.</param>
        public static void OnVoteEnded(VoteEndedEventArgs ev) => VoteEnded?.InvokeEvent(ev);

        /// <summary>
        /// Called before a vote ends.
        /// </summary>
        /// <param name="ev">The <see cref="VoteEndedEventArgs"/> instance.</param>
        public static void OnVoteEnding(VoteEndingEventArgs ev) => VoteEnding?.InvokeEvent(ev);

        private static void InvokeEvent<T>(this CustomEventHandler<T> eventHandler, T args)
            where T : System.EventArgs
        {
            if (eventHandler == null)
            {
                return;
            }

            foreach (Delegate del in eventHandler.GetInvocationList())
            {
                if (del is not CustomEventHandler<T> customDelegate)
                {
                    continue;
                }

                try
                {
                    customDelegate(args);
                }
                catch (Exception exception)
                {
                    Trace.TraceError(exception.ToString());
                }
            }
        }
    }
}