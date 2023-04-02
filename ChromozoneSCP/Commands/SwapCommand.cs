using System;
using CommandSystem;
using PlayerRoles;
using PluginAPI.Core;

namespace ChromozoneSCP.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class SwapCommand : ParentCommand
    {
        public override string Command => "swap";

        public override string[] Aliases { get; } = {};

        public override string Description => "Allows you to swap your SCP with another SCP player.";
        
        private int Timeout => Plugin.Instance.Config.SwapTimeout;
        
        public SwapCommand() => LoadGeneratedCommands();
        
        public override void LoadGeneratedCommands()
        {
            RegisterCommand(new AcceptSwapCommand());
            RegisterCommand(new CancelSwapCommand());
            RegisterCommand(new DeclineSwapCommand());
            RegisterCommand(new RolesSwapCommand());
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
                response = "You can only use this command during a round.";
                return false;
            }

            if (Round.Duration > TimeSpan.FromSeconds(Timeout))
            {
                response = $"You can only swap roles within the first {Timeout} seconds of the round.";
                return false;
            }

            if (player.Team != Team.SCPs)
            {
                response = "You must be an SCP to use this command.";
                return false;
            }

            response = "Unable to locate a player with the requested role or name.";
            return false;
        }

        private static Player GetReceiver(string request, out Action<Player> spawn)
        {
            spawn = null;
            return null;
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

        private class CancelSwapCommand : ICommand
        {
            public string Command => "cancel";
            
            public string[] Aliases { get; } = { "c" };
            
            public string Description => "Cancels a swap request from another player.";
            
            public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
            {
                var player = Player.Get(sender);
                response = "Unable to locate a player with the requested role or name.";
                return false;
            }
        }
        
        private class DeclineSwapCommand : ICommand
        {
            public string Command => "decline";
            
            public string[] Aliases { get; } = { "d" };
            
            public string Description => "Declines a swap request from another player.";
            
            public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
            {
                var player = Player.Get(sender);
                response = "Unable to locate a player with the requested role or name.";
                return false;
            }
        }
        
        private class RolesSwapCommand : ICommand
        {
            public string Command => "roles";
            
            public string[] Aliases { get; } = { "r" };
            
            public string Description => "Lists all the roles that can be swapped.";
            
            public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
            {
                var player = Player.Get(sender);
                response = "Unable to locate a player with the requested role or name.";
                return false;
            }
        } 
    }
}