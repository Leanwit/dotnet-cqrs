using System;
using System.Threading.Tasks;

namespace CQRS.Shared.Domain.Bus.Command
{
    public interface CommandHandler<T> where T: Command
    {
        Task Handle(T command);
    }
}