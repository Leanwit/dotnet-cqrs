using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Todo.Shared.Domain.Bus;

namespace CQRS.Todo.Shared.Infrastructure.Bus
{
    public class InMemoryQueryBus : QueryBus
    {
        private readonly IServiceProvider _provider;
        private static readonly ConcurrentDictionary<Type, object> _queryHandlers = new ConcurrentDictionary<Type, object>();

        public InMemoryQueryBus(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<TResponse> Send<TResponse>(Query query)
        {
            var handler = GetWrappedHandlers<TResponse>(query);
            
            if(handler == null) throw new QueryNotRegisteredError(query);

            return await handler.Handle(query, _provider);
        }
        
        private QueryHandlerWrapper<TResponse> GetWrappedHandlers<TResponse>(Query query)
        {
            Type[] typeArgs = {query.GetType(), typeof(TResponse)};
            
            var handlerType = typeof(QueryHandler<,>).MakeGenericType(typeArgs);
            Type wrapperType = typeof(QueryHandlerWrapper<,>).MakeGenericType(typeArgs);

            IEnumerable handlers =
                (IEnumerable) _provider.GetService(typeof(IEnumerable<>).MakeGenericType(handlerType));


            var wrappedHandlers = (QueryHandlerWrapper<TResponse>)_queryHandlers.GetOrAdd(query.GetType(), handlers.Cast<object>()
                .Select(handler => (QueryHandlerWrapper<TResponse>) Activator.CreateInstance(wrapperType)).FirstOrDefault());

            return wrappedHandlers;
        }
    }
}