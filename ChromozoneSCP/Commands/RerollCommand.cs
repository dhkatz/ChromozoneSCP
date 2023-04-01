using System;
using CommandSystem;

namespace ChromozoneSCP.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class RerollCommand : ParentCommand
    {
        public override string Command { get; } = "reroll";

        public override string[] Aliases { get; } = { "rr" };
        
        public override string Description { get; } = "Allows you to reroll your SCP.";
        
        public RerollCommand() => LoadGeneratedCommands();
        
        public override void LoadGeneratedCommands()
        {
            
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            throw new NotImplementedException();
        }
    }
}