using System.Threading.Tasks;

namespace CQRS.Shared.Domain.Bus
{
    public interface CommandBus
    {
        Task Dispatch(Command command);
    }
}