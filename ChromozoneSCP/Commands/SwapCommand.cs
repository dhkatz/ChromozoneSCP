using System;
using CommandSystem;
using PluginAPI.Core;

namespace ChromozoneSCP.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class SwapCommand : ParentCommand
    {
        public override string Command => "swap";

        public override string[] Aliases { get; } = {};

        public override string Description => "Allows you to swap your SCP with another SCP player.";
        
        public SwapCommand() => LoadGeneratedCommands();
        
        public override void LoadGeneratedCommands()
        {
            RegisterCommand(new AcceptSwapCommand());
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var player = Player.Get(sender);

            if (player == null)
            {
                response = "You must be a player to use this command.";
                return false;
            }

            if (!Round.IsRoundStarted)
            {
                
            }

            response = "Unable to locate a player with the requested role or name.";
            return false;
        }

        private class AcceptSwapCommand : ICommand
        {
            public string Command => "accept";
            
            public string[] Aliases { get; } = { "a" };
            
            public string Description => "Accepts a swap request from another player.";
            
            public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
            {
                var player = Player.Get(sender);
                response = "Unable to locate a player with the requested role or name.";
                return false;
            }
        }
    }
}