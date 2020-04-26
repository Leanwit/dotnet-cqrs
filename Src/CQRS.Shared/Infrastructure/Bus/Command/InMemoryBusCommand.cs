using System;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Shared.Domain.Bus.Command;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Shared.Infrastructure.Bus.Command
{
    public class InMemoryCommandBus : CommandBus
    {
        private readonly CommandHandlersInformation _information;
        private readonly IServiceProvider _serviceProvider;

        public InMemoryCommandBus(IServiceProvider serviceProvider, CommandHandlersInformation information)
        {
            _serviceProvider = serviceProvider;
            this._information = information;
        }

        public async Task Dispatch(Domain.Bus.Command.Command command)
        {
            var commandHandlerClass =
                _information.IndexedCommandHandlers.FirstOrDefault(x => x.Key == command.GetType()).Value;

            if (commandHandlerClass == null) throw new CommandNotRegisteredError(command);

            try
            {
                Type handlerType = typeof(CommandHandler<>).MakeGenericType(command.GetType());
                using IServiceScope scope = _serviceProvider.CreateScope();
                dynamic handlers = scope.ServiceProvider.GetServices(handlerType);
                
                foreach (var handler in handlers)
                {
                    await handler.Handle(command);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}