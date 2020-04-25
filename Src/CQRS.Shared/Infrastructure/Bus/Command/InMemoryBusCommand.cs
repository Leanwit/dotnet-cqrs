using System;
using System.Threading.Tasks;
using CQRS.Shared.Domain.Bus.Command;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Shared.Infrastructure.Bus.Command
{
    public class InMemoryCommandBus : CommandBus
    {
        private readonly CommandHandlersInformation _information;
        private readonly ServiceProvider _serviceProvider;

        public InMemoryCommandBus(ServiceProvider serviceProvider, CommandHandlersInformation information)
        {
            _serviceProvider = serviceProvider;
            this._information = information;
        }

        public Task Dispatch(Domain.Bus.Command.Command command)
        {
            throw new NotImplementedException();
        }
    }
}