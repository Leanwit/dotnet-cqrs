using System.Threading.Tasks;

namespace CQRS.Shared.Domain.Bus.Command
{
    internal abstract class CommandHandlerWrapper
    {
        public abstract Task Handle(Command command);
    }

    internal class CommandHandlerWrapper<TCommand> : CommandHandlerWrapper
        where TCommand : Command
    {
        private readonly CommandHandler<TCommand> _handler;

        public CommandHandlerWrapper(CommandHandler<TCommand> handler)
        {
            _handler = handler;
        }

        public override Task Handle(Command domainEvent)
        {
            return _handler.Handle((TCommand) domainEvent);
        }
    }
}