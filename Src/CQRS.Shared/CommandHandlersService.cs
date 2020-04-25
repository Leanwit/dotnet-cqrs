using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CQRS.Shared.Domain.Bus;
using CQRS.Shared.Domain.Bus.Command;
using CQRS.Shared.Infrastructure.Bus.Command;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Shared
{
    public static class CommandHandlersService
    {
        public static IServiceCollection AddCommandHandlersService(this IServiceCollection services,
            Assembly assembly)
        {
            var indexedCommandHandlers =
                new Dictionary<Type, Type>();

            var classTypes = assembly.ExportedTypes.Select(t => t.GetTypeInfo()).Where(t => t.IsClass && !t.IsAbstract);

            foreach (var type in classTypes)
            {
                var interfaces = type.ImplementedInterfaces.Select(i => i.GetTypeInfo());

                foreach (var handlerInterfaceType in interfaces.Where(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(CommandHandler<>)))
                {
                    FormatSubscribers(assembly, handlerInterfaceType, indexedCommandHandlers);
                }
            }

            services.AddScoped(s => new CommandHandlersInformation(indexedCommandHandlers));
            return services;
        }

        private static void FormatSubscribers(Assembly assembly, TypeInfo handlerInterfaceType,
            Dictionary<Type, Type> information)
        {
            var handlerClassTypes = assembly.GetLoadableTypes()
                .Where(handlerInterfaceType.IsAssignableFrom);

            var eventType = handlerInterfaceType.GenericTypeArguments.FirstOrDefault();

            if (eventType == null) return;

            foreach (var handlerClassType in handlerClassTypes)
            {
                information.Add(handlerClassType, eventType);
            }
        }

        private static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }
    }
}