using System;
using CommandSystem;

namespace ChromozoneSCP.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class RerollCommand : ParentCommand
    {
        public override string Command => "reroll";

        public override string[] Aliases { get; } = { "rr" };
        
        public override string Description => "Allows you to reroll your SCP.";

        public RerollCommand() => LoadGeneratedCommands();
        
        public sealed override void LoadGeneratedCommands()
        {
            RegisterCommand(new AcceptRerollCommand());
            RegisterCommand(new CancelRerollCommand());
            RegisterCommand(new RolesRerollCommand());
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            throw new NotImplementedException();
        }
        
        private class AcceptRerollCommand : ICommand
        {
            public string Command => "accept";

            public string[] Aliases { get; } = { "a" };
            
            public string Description => "Accepts the started reroll.";

            public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
            {
                throw new NotImplementedException();
            }
        }
        
        private class CancelRerollCommand : ICommand
        {
            public string Command => "cancel";

            public string[] Aliases { get; } = { "c" };
            
            public string Description => "Cancels the started reroll.";

            public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
            {
                throw new NotImplementedException();
            }
        }
        
        private class RolesRerollCommand : ICommand
        {
            public string Command => "roles";

            public string[] Aliases { get; } = { "r" };
            
            public string Description => "List the available roles to reroll to.";

            public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
            {
                throw new NotImplementedException();
            }
        }
    }
}