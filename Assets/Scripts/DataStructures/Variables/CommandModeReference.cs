using System;

namespace General_Logic.Variables
{
    [Serializable]
    public class CommandModeReference : AbstractReference<CommandMode>
    {
        public CommandModeReference(CommandMode value) : base(value)
        {
        }
    }
}
