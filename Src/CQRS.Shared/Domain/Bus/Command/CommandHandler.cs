using System.Threading.Tasks;

namespace CQRS.Shared.Domain.Bus.Command
{
    public interface CommandHandler<TCommand> where TCommand : Command
    {
        Task Handle(TCommand domainEvent);
    }
}