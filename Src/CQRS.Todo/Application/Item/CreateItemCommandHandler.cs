using System.Threading.Tasks;
using CQRS.Shared.Domain.Bus.Command;

namespace CQRS.Todo.Application.Item
{
    public class CreateItemCommandHandler : CommandHandle<CreateItemCommand>
    {
        public async Task Handle(CreateItemCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}