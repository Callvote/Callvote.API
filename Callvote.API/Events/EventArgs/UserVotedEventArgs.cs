using Callvote.API.Events.Interfaces;
using Callvote.API.Features.Votes;

namespace Callvote.API.Events.EventArgs
{
    /// <summary>
    /// Contains all information about a <see cref="UserIdentifier"/> that has voted on a <see cref="Vote"/> with a specific <see cref="VoteOption"/>.
    /// </summary>
    public class UserVotedEventArgs : System.EventArgs, IUserIdentifierEvent, IVoteEvent, IVoteOptionEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserVotedEventArgs"/> class.
        /// </summary>
        /// <param name="user">The <inheritdoc cref="UserIdentifier"/> that voted.</param>
        /// <param name="voteOption"><inheritdoc cref="VoteOption"/></param>
        /// <param name="vote"><inheritdoc cref="Vote"/></param>
        public UserVotedEventArgs(UserIdentifier user, Vote vote, VoteOption voteOption)
        {
            this.User = user;
            this.Vote = vote;
            this.VoteOption = voteOption;
        }

        /// <inheritdoc />
        public UserIdentifier User { get; }

        /// <inheritdoc />
        public Vote Vote { get; }

        /// <inheritdoc />
        public VoteOption VoteOption { get; }
    }
}
