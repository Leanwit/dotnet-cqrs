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

            foreach (CommandHandler handler in wrappedHandlers)
            {
                await handler.Handle(command).ConfigureAwait(false);
            }
        }

        private IEnumerable<CommandHandler> GetWrappedHandlers(Domain.Bus.Command.Command domainEvent)
        {
            Type handlerType = typeof(CommandHandle<>).MakeGenericType(domainEvent.GetType());
            Type wrapperType = typeof(CommandHandler<>).MakeGenericType(domainEvent.GetType());

            IEnumerable handlers =
                (IEnumerable) _provider.GetService(typeof(IEnumerable<>).MakeGenericType(handlerType));

            IEnumerable<CommandHandler> wrappedHandlers = handlers.Cast<object>()
                .Select(handler => (CommandHandler) Activator.CreateInstance(wrapperType, handler));
            return wrappedHandlers;
        }
    }
}