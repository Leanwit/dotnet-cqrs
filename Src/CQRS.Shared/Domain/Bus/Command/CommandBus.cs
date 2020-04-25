using System.Threading.Tasks;

namespace CQRS.Shared.Domain.Bus.Command
{
    public interface CommandBus
    {
        Task Dispatch(Command command);
    }
}