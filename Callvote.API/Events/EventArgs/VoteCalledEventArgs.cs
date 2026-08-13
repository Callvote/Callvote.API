using Callvote.API.Enums;
using Callvote.API.Events.Interfaces;
using Callvote.API.Features.Votes;

namespace Callvote.API.Events.EventArgs
{
    /// <summary>
    /// Contains all information about a <see cref="Vote"/> that has been called.
    /// </summary>
    public class VoteCalledEventArgs : System.EventArgs, IUserIdentifierEvent, IVoteEvent, IVoteStatusEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VoteCalledEventArgs"/> class.
        /// </summary>
        /// <param name="vote"><inheritdoc cref="Vote"/></param>
        /// <param name="status"><inheritdoc cref="Status"/></param>
        public VoteCalledEventArgs(Vote vote, CallVoteStatus status)
        {
            this.Vote = vote;
            this.Status = status;
        }

        /// <inheritdoc />
        public UserIdentifier User => this.Vote.CallVotePlayer;

        /// <inheritdoc />
        public Vote Vote { get; }

        /// <summary>
        /// Gets the <see cref="CallVoteStatus"/> the <see cref="Vote"/> was called with.
        /// </summary>
        /// <remarks>
        /// This event is invoked for every outcome, so the <see cref="Vote"/> has only started when this is <see cref="CallVoteStatus.VoteStarted"/>.
        /// </remarks>
        public CallVoteStatus Status { get; }
    }
}
