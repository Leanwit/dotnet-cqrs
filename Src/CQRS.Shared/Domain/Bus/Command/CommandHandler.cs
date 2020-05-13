using System.Threading.Tasks;

namespace CQRS.Shared.Domain.Bus
{
    public interface CommandHandler<TCommand> where TCommand : Command
    {
        Task Handle(TCommand domainEvent);
    }
}