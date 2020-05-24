using System;
using System.Threading.Tasks;
using CQRS.Todo.Shared.Domain.Bus;
using Command = CQRS.Todo.Shared.Domain.Bus.Command;

namespace CQRS.Todo.Shared.Infrastructure.Bus
{
    internal abstract class CommandHandlerWrapper
    {
        public abstract Task Handle(Command command, IServiceProvider provider);
    }

    internal class CommandHandlerWrapper<TCommand> : CommandHandlerWrapper
        where TCommand : Command
    {
        public override Task Handle(Command domainEvent, IServiceProvider provider)
        {
            var handler = (CommandHandler<TCommand>) provider.GetService(typeof(CommandHandler<TCommand>));
            return handler.Handle((TCommand) domainEvent);
        }
    }
}