using System.Threading.Tasks;

namespace CQRS.Shared.Domain.Bus.Command
{
    public interface CommandHandler<T> where T: Bus.Command.Command
    {
        Task Handle(T command);
    }
}