using System;

namespace CQRS.Todo.Shared.Domain.Bus
{
    public class CommandNotRegisteredError : Exception
    {
        public CommandNotRegisteredError(Command command) : base(
            $"The command {command} has not a command handler associated")
        {
        }
    }
}