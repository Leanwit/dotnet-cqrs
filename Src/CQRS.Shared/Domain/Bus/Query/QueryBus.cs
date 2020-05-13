using System.Threading.Tasks;

namespace CQRS.Shared.Domain.Bus
{
    public interface QueryBus
    {
        Task<TResponse> Send<TResponse>(Query request);
    }
}