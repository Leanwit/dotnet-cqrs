using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Shared.Domain.Bus.Command;

namespace CQRS.Shared.Infrastructure.Bus.Command
{
    public class InMemoryCommandBus : CommandBus
    {
        private readonly IServiceProvider _provider;

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

        private IEnumerable<CommandHandlerWrapper> GetWrappedHandlers(Domain.Bus.Command.Command domainEvent)
        {
            Type handlerType = typeof(CommandHandler<>).MakeGenericType(domainEvent.GetType());
            Type wrapperType = typeof(CommandHandlerWrapper<>).MakeGenericType(domainEvent.GetType());

            IEnumerable handlers =
                (IEnumerable) _provider.GetService(typeof(IEnumerable<>).MakeGenericType(handlerType));

            IEnumerable<CommandHandlerWrapper> wrappedHandlers = handlers.Cast<object>()
                .Select(handler => (CommandHandlerWrapper) Activator.CreateInstance(wrapperType, handler));
            return wrappedHandlers;
        }
    }
}