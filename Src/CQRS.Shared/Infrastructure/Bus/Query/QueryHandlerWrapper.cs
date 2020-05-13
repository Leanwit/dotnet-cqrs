using System;
using System.Threading.Tasks;
using CQRS.Shared.Domain.Bus;

namespace CQRS.Shared.Infrastructure.Bus
{
    internal abstract class QueryHandlerWrapper<TResponse>
    {
        public abstract Task<TResponse> Handle(Query query, IServiceProvider provider);
    }

    internal class QueryHandlerWrapper<TQuery, TResponse> : QueryHandlerWrapper<TResponse>
        where TQuery : Query
    {
        public override Task<TResponse> Handle(Query query, IServiceProvider provider)
        {
            var handler = (QueryHandler<TQuery, TResponse>) provider.GetService(typeof(QueryHandler<TQuery, TResponse>));

            return handler.Handle((TQuery) query);
        }
    }
}