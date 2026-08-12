#if !BAREBONES

using System;
using System.Collections.Generic;
using Callvote.API.Features.Votes;
using LabApi.Features.Wrappers;

namespace Callvote.API.Features.Displays.DefaultProviders
{
    /// <summary>
    /// Represents the type that provides broadcasts messages.
    /// </summary>
    public class BroadcastProvider : DisplayProvider
    {
        /// <inheritdoc/>
        public override string Name => "Callvote.API.Broadcast";

        /// <inheritdoc/>
        public override void Show(TimeSpan duration, string content, UserIndentifier player, float? position = null)
        {
            Player p = Player.Get(player.UserId);

            if (p == null)
            {
                return;
            }

            Server.SendBroadcast(p, message: content, duration: (ushort)duration.TotalSeconds);
        }
    }
}

#endif