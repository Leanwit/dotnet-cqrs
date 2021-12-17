using System.Threading.Tasks;

namespace CQRS.Todo.Shared.Domain.Bus.Commands;

public interface CommandHandler<TCommand> where TCommand : Command
{
    Task Handle(TCommand domainEvent);
}