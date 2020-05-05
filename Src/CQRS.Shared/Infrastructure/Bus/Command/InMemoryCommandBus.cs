using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Shared.Domain.Bus.Command;
using CQRS.Shared.Domain.Bus.Query;

namespace CQRS.Shared.Infrastructure.Bus.Command
{
    public class InMemoryCommandBus : CommandBus
    {
        private readonly IServiceProvider _provider;
        private static readonly ConcurrentDictionary<Type, IEnumerable<CommandHandlerWrapper>> _commandHandlers = new ConcurrentDictionary<Type, IEnumerable<CommandHandlerWrapper>>();

        public InMemoryCommandBus(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task Dispatch(Domain.Bus.Command.Command command)
        {
            var wrappedHandlers = GetWrappedHandlers(command);
            
            if(wrappedHandlers == null) throw new CommandNotRegisteredError(command);
            
            foreach (CommandHandlerWrapper handler in wrappedHandlers)
            {
                await handler.Handle(command).ConfigureAwait(false);
            }
        }

        private IEnumerable<CommandHandlerWrapper> GetWrappedHandlers(Domain.Bus.Command.Command command)
        {
            Type handlerType = typeof(CommandHandler<>).MakeGenericType(command.GetType());
            Type wrapperType = typeof(CommandHandlerWrapper<>).MakeGenericType(command.GetType());

            IEnumerable handlers =
                (IEnumerable) _provider.GetService(typeof(IEnumerable<>).MakeGenericType(handlerType));

            var wrappedHandlers = _commandHandlers.GetOrAdd(command.GetType(), handlers.Cast<object>()
                .Select(handler => (CommandHandlerWrapper) Activator.CreateInstance(wrapperType, handler)));
            
            return wrappedHandlers;
        }
    }
}