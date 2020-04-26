using System.Threading.Tasks;

namespace CQRS.Shared.Domain.Bus.Command
{
    public interface CommandHandle<T> where T : Command
    {
        Task Handle(T domainEvent);
    }
}