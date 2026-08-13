#if !BAREBONES

using Callvote.API.Features.Commands.DefaultCommands;
using CommandSystem;
using RemoteAdmin;

#pragma warning disable CS1591

namespace Callvote.API.Features.Commands.DefaultProviders
{
    public class SecretLabCommandProvider : CommandProvider
    {
        public override string Name => "SecretLabCommandProvider";

        public override void RegisterCommand(VoteCommand command)
        {
            command.Command = command.VoteOption.Option;

            while (this.IsCommandRegistered(command))
            {
                command.Command = "cv" + command.Command;
            }

            QueryProcessor.DotCommandHandler.RegisterCommand(new SecretLabCommand(command));
        }

        public override void UnregisterCommand(VoteCommand command)
        {
            if (!QueryProcessor.DotCommandHandler.TryGetCommand(command.Command, out ICommand cmd))
            {
                return;
            }

            QueryProcessor.DotCommandHandler.UnregisterCommand(cmd);
        }

        public override bool IsCommandRegistered(VoteCommand command) => QueryProcessor.DotCommandHandler.TryGetCommand(command.Command, out _);
    }
}

#endif