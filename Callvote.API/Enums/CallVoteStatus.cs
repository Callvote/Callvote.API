using Callvote.API.Features.Votes;

namespace Callvote.API.Enums
{
    /// <summary>
    /// Represents the enumeration for the <see cref="VoteHandler.CallVote(Vote, bool)"/> Status.
    /// </summary>
    public enum CallVoteStatus
    {
        /// <summary><see cref="Vote"/>  was enqueued.</summary>
        VoteEnqueued = -1,

        /// <summary>The <see cref="Vote"/> was canceled.</summary>
        VoteCanceled = 0,

        /// <summary><see cref="Vote"/>  has started.</summary>
        VoteStarted = 1,

        /// <summary>There is a <see cref="Vote"/> currently in progress.</summary>
        VoteInProgress = 2,

        /// <summary>The Queue is full.</summary>
        QueueIsFull = 3,

        /// <summary>The Queue is disabled.</summary>
        QueueDisabled = 4,

        /// <summary>The Player reached the maximum amount of votes in a round.</summary>
        MaxedCallVotes = 5,
    }
}
