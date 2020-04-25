using System;
using System.Collections.Generic;

namespace CQRS.Shared.Infrastructure.Bus.Command
{
    public class CommandHandlersInformation
    {
        public Dictionary<Type, Type> IndexedCommandHandlers { get; private set; }

        public CommandHandlersInformation(Dictionary<Type, Type> indexedCommandHandlers)
        {
            IndexedCommandHandlers = indexedCommandHandlers;
        }

    }
}