using System.Threading.Tasks;

namespace CQRS.Todo.Shared.Domain.Bus
{
    public interface CommandBus
    {
        Task Dispatch(Command command);
    }
}