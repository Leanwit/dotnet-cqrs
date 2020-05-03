using System.Threading.Tasks;

namespace CQRS.Shared.Domain.Bus.Query
{
    public interface QueryBus
    {
        Task<TResponse> Send<TResponse>(Query request);
    }
}