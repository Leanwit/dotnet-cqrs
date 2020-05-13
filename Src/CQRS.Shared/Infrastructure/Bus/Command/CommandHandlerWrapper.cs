using System;
using System.Threading.Tasks;
using CQRS.Shared.Domain.Bus.Command;

namespace CQRS.Shared.Infrastructure.Bus.Command
{
    internal abstract class CommandHandlerWrapper
    {
        public abstract Task Handle(Domain.Bus.Command.Command command, IServiceProvider provider);
    }

    internal class CommandHandlerWrapper<TCommand> : CommandHandlerWrapper
        where TCommand : Domain.Bus.Command.Command
    {
        public override Task Handle(Domain.Bus.Command.Command domainEvent, IServiceProvider provider)
        {
            var handler = (CommandHandler<TCommand>) provider.GetService(typeof(CommandHandler<TCommand>));
            return handler.Handle((TCommand) domainEvent);
        }
    }
}