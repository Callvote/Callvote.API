using Callvote.API.Enums;
using Callvote.API.Events.Interfaces;
using Callvote.API.Features.Votes;

namespace Callvote.API.Events.EventArgs
{
    /// <summary>
    /// Contains all information about a <see cref="Vote"/> that is being called.
    /// </summary>
    public class CallingVoteEventArgs : System.EventArgs, IUserIdentifierEvent, IVoteEvent, IDeniableEvent, IVoteStatusEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallingVoteEventArgs"/> class.
        /// </summary>
        /// <param name="vote"><inheritdoc cref="Vote"/></param>
        /// <param name="isAllowed"><inheritdoc cref="IsAllowed"/></param>
        public CallingVoteEventArgs(Vote vote, bool isAllowed = true)
        {
            this.Vote = vote;
            this.IsAllowed = isAllowed;
        }

        /// <inheritdoc />
        public UserIdentifier User => this.Vote.CallVotePlayer;

        /// <inheritdoc />
        public Vote Vote { get; }

        /// <inheritdoc />
        public bool IsAllowed { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="CallVoteStatus"/> returned to the caller when <see cref="IsAllowed"/> is false.
        /// </summary>
        public CallVoteStatus Status { get; set; }
    }
}
