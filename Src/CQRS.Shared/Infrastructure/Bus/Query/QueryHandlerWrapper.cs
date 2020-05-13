using System;
using System.Threading.Tasks;
using CQRS.Shared.Domain.Bus.Query;

namespace CQRS.Shared.Infrastructure.Bus.Query
{
    internal abstract class QueryHandlerWrapper<TResponse>
    {
        public abstract Task<TResponse> Handle(Domain.Bus.Query.Query query, IServiceProvider provider);
    }

    internal class QueryHandlerWrapper<TQuery, TResponse> : QueryHandlerWrapper<TResponse>
        where TQuery : Domain.Bus.Query.Query
    {
        public override Task<TResponse> Handle(Domain.Bus.Query.Query query, IServiceProvider provider)
        {
            var handler = (QueryHandler<TQuery, TResponse>) provider.GetService(typeof(QueryHandler<TQuery, TResponse>));

            return handler.Handle((TQuery) query);
        }
    }
}