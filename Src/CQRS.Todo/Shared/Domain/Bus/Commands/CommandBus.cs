using System.Threading.Tasks;

namespace CQRS.Todo.Shared.Domain.Bus.Commands;

public interface CommandBus
{
    Task Dispatch(Command command);
}