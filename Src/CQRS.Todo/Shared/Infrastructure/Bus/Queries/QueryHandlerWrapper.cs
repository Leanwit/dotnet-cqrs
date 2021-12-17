using System;
using System.Threading.Tasks;
using CQRS.Todo.Shared.Domain.Bus.Queries;

namespace CQRS.Todo.Shared.Infrastructure.Bus.Queries;

internal abstract class QueryHandlerWrapper<TResponse>
{
    public abstract Task<TResponse> Handle(Query query, IServiceProvider provider);
}

internal class QueryHandlerWrapper<TQuery, TResponse> : QueryHandlerWrapper<TResponse>
    where TQuery : Query
{
    public override async Task<TResponse> Handle(Query query, IServiceProvider provider)
    {
        var handler = (QueryHandler<TQuery, TResponse>)provider.GetService(typeof(QueryHandler<TQuery, TResponse>));

        if (handler == null)
            throw new NullReferenceException($"{nameof(QueryHandlerWrapper<TQuery, TResponse>)} Handler not found");
        
        return await handler.Handle((TQuery)query);
    }
}