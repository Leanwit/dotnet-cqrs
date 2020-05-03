using System.Threading.Tasks;
namespace CQRS.Shared.Domain.Bus.Query
{
    internal abstract class QueryHandlerWrapper<TResponse>
    {
        public abstract Task<TResponse> Handle(Query query);
    }

    internal class QueryHandlerWrapper<TQuery, TResponse> : QueryHandlerWrapper<TResponse>
        where TQuery : Query
    {
        private readonly QueryHandler<TQuery,TResponse>  _handler;

        public QueryHandlerWrapper(QueryHandler<TQuery, TResponse> handler)
        {
            _handler = handler;
        }
        
        public override Task<TResponse> Handle(Query query)
        {
            return _handler.Handle((TQuery) query);
        }
    }
}