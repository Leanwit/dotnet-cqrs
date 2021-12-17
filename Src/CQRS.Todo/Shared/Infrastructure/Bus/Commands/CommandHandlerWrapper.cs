using System;
using System.Threading.Tasks;
using CQRS.Todo.Shared.Domain.Bus.Commands;

namespace CQRS.Todo.Shared.Infrastructure.Bus.Commands;

internal abstract class CommandHandlerWrapper
{
    public abstract Task Handle(Command command, IServiceProvider provider);
}

internal class CommandHandlerWrapper<TCommand> : CommandHandlerWrapper
    where TCommand : Command
{
    public override async Task Handle(Command domainEvent, IServiceProvider provider)
    {
        var handler = (CommandHandler<TCommand>) provider.GetService(typeof(CommandHandler<TCommand>));
        await handler.Handle((TCommand) domainEvent);
    }
}