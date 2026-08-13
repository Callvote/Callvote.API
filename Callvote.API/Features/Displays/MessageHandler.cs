#if !BAREBONES
using Callvote.API.Features.Displays.DefaultProviders;
using UnityEngine;
#endif
using System;
using System.Collections.Generic;
using Callvote.API.Enums;
using Callvote.API.Features.Extensions;
using Callvote.API.Features.Generic;
using Callvote.API.Features.Votes;

namespace Callvote.API.Features.Displays
{
    /// <summary>
    /// Represents the type that displays the messages during the vote lifecycle, such as the first message with the question and options, the message that updates while vote is active, and the final results message.
    /// </summary>
    public class MessageHandler : BaseProviderHandler<DisplayProvider>
    {
        private DisplayProvider currentProvider;

        /// <summary>
        /// Gets the current instance of the Display system.
        /// </summary>
        public static MessageHandler Instance { get; } = new MessageHandler();

        /// <inheritdoc/>
        public override Dictionary<string, DisplayProvider> Providers { get; } = [];

        /// <inheritdoc/>
        public override DisplayProvider CurrentProvider
        {
            get => this.currentProvider ??= GetDisplayProvider();
            internal set => this.currentProvider = value;
        }

        /// <inheritdoc/>
        public override ProviderType ProviderHandlerType => ProviderType.DisplayMessage;

        /// <summary>
        /// Displays the initial message to <see cref="Vote.AllowedPlayers"/> based on the <see cref="CurrentProvider"/>.
        /// </summary>
        /// <param name="duration">The message duration.</param>
        /// <param name="message">The message to be displayed.</param>
        /// <param name="user">The player that will see the message.</param>
        /// <param name="position">The position of the message.</param>
        /// <param name="vote">The <see cref="Vote"/> the message belongs to. Defaults to the <see cref="VoteHandler.CurrentVote"/> when null.</param>
        public static void Show(float duration, string message, UserIdentifier user, float? position = null, Vote vote = null)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            Instance.CurrentProvider?.Show(
                TimeSpan.FromSeconds(Math.Max(0, duration)),
                $"<size={CalculateMessageSize(message, vote)}>{message}</size>",
                user,
                position);
        }

        /// <summary>
        /// Displays the initial message to <see cref="Vote.AllowedPlayers"/> based on the <see cref="CurrentProvider"/>.
        /// </summary>
        /// <param name="duration">The message duration.</param>
        /// <param name="message">The message to be displayed.</param>
        /// <param name="users">The players that will see the message.</param>
        /// <param name="position">The position of the message.</param>
        /// <param name="vote">The <see cref="Vote"/> the message belongs to. Defaults to the <see cref="VoteHandler.CurrentVote"/> when null.</param>
        public static void Show(float duration, string message, IEnumerable<UserIdentifier> users, float? position = null, Vote vote = null)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            foreach (UserIdentifier user in users)
            {
                Instance.CurrentProvider?.Show(
                    TimeSpan.FromSeconds(Math.Max(0, duration)),
                    $"<size={CalculateMessageSize(message, vote)}>{message}</size>",
                    user,
                    position);
            }
        }

        /// <summary>
        /// Calculates the size tag for the message based on its length and Callvote's configuration.
        /// </summary>
        /// <param name="message">The message to have it's size calculated.</param>
        /// <param name="vote">The <see cref="Vote"/> whose <see cref="Vote.MessageSize"/> is used. Defaults to the <see cref="VoteHandler.CurrentVote"/> when null.</param>
        /// <remarks>
        /// This values only work for SL.
        /// </remarks>
        /// <returns>A number for the size tag.</returns>
        public static int CalculateMessageSize(string message, Vote vote = null)
        {
            int defaultSize = 52;
            int sizeReduction = message.Length / 4;

            vote ??= VoteHandler.CurrentVote;

            if (vote != null && vote.MessageSize != 0)
            {
                defaultSize = vote.MessageSize;
                return defaultSize;
            }

            defaultSize -= sizeReduction;
            return defaultSize.Clamp(30, 52);
        }

        private static DisplayProvider GetDisplayProvider()
        {
#if !BAREBONES
            if (Application.productName == "SCPSL")
            {
                return new BroadcastProvider();
            }
#endif
            return null;
        }
    }
}
