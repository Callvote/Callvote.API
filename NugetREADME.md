# Callvote

**The sucessor of [callvote](https://github.com/PatPeter/callvote).**

A plugin that allows calling and vote for **Kick**,
 **RestartRound**,  **Kill**,
**RespawnWave**, **FriendlyFire**, or **Custom** Votes using **KEYBINDS** or **CONSOLE COMMANDS** in the same format as the Source Engine (Left 4
Dead
2/Counter-Strike: Global Offensive).

## Examples
```cs
VoteHandler.CreateVoteOption("command", "<color=red>detail</color>", out _);
VoteHandler.CreateVoteOption("command2", "<color=green>detail2</color>", out _);
VoteHandler.CallVote(new CustomVote(player, $"<color=#D681DE>question</color>", "CallvoteExample.Template"));
```

```cs
VoteHandler.CallVote(new CustomVote(player, $"{player.Nickname} asks: Enable FF?", "CallvoteExample.FF", new FFVote(player)));
```

```cs
private void ReviveSCPs(DiedEventArgs ev)
{
    if (ev.Player.IsScp)
    {
        void Callback(Vote vote)
        {
            if (vote is not BinaryVote binaryVote)
            {
                return;
            }

            int yesPercentage = vote.GetVoteOptionPercentage(binaryVote.YesVoteOption);
            int noPercentage = vote.GetVoteOptionPercentage(binaryVote.NoVoteOption);

            if (yesPercentage > noPercentage)
            {
                ev.Player.RoleManager.ServerSetRole(ev.TargetOldRole, PlayerRoles.RoleChangeReason.None);
                Map.Broadcast(5, $"{ev.TargetOldRole} respawned.");
                return;
            }

            Map.Broadcast(5, "The Vote Failed.");
        }

        BinaryVote reviveSCP = new BinaryVote(Server.Host, $"Revive {ev.TargetOldRole}?", $"NothingBurguerPlugin.Respawn", Callback);
        VoteHandler.CallVote(reviveSCP);
    }
}
```

## Documentation

> https://unbistrackted.github.io/Callvote/

## Special thanks to:

https://github.com/Playeroth and https://github.com/Edi369 for helping me with translations and adding webhook functionality.

https://github.com/PatPeter for giving the permission to continue the development of [callvote](https://github.com/PatPeter/callvote).

https://github.com/vladflotsky for giving adivice and guidance while I was rewritting the plugin.
