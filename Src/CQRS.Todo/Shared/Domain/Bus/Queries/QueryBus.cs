using System.Threading.Tasks;

namespace CQRS.Todo.Shared.Domain.Bus.Queries
{
    public interface QueryBus
    {
        Task<TResponse> Send<TResponse>(Query request);
    }
}