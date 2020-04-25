using System;

namespace CQRS.Shared.Domain.Bus.Command
{
    public class CommandNotRegisteredError : Exception
    {
        public CommandNotRegisteredError(Bus.Command.Command command) : base(
            $"The command {command} hasn't a command handler associated")
        {
        }
    }
}