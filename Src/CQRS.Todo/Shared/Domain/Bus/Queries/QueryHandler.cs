using System.Threading.Tasks;

namespace CQRS.Todo.Shared.Domain.Bus.Queries;

public interface QueryHandler<TQuery, TResponse> where TQuery : Query
{
    Task<TResponse> Handle(TQuery query);
}