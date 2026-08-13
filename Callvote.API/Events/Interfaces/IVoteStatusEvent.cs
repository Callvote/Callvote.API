using Callvote.API.Enums;

namespace Callvote.API.Events.Interfaces
{
    /// <summary>
    /// Event args used for all <see cref="Features.Votes.Vote"/> related events.
    /// </summary>
    public interface IVoteStatusEvent
    {
        /// <summary>
        /// Gets the <see cref="Enums.CallVoteStatus"/> related to the event.
        /// </summary>
        public CallVoteStatus Status { get; }
    }
}