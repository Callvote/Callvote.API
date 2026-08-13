using Callvote.API.Features.Votes;

namespace Callvote.API.Events.Interfaces
{
    /// <summary>
    /// Event args used for all UserIdentifier related events.
    /// </summary>
    public interface IUserIdentifierEvent
    {
        /// <summary>
        /// Gets the UserIdentifier triggering the event.
        /// </summary>
        public UserIdentifier User { get; }
    }
}
