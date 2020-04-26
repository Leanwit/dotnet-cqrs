using System.Threading.Tasks;

namespace CQRS.Shared.Domain.Bus.Command
{
    public abstract class CommandHandler
    {
        public abstract Task Handle(Command command);
    }

    public class CommandHandler<T> : CommandHandler
        where T : Command
    {
        private readonly CommandHandle<T> _handler;

        public CommandHandler(CommandHandle<T> handler)
        {
            _handler = handler;
        }

        public override Task Handle(Command domainEvent)
        {
            return _handler.Handle((T) domainEvent);
        }
    }
}