using System.Threading.Tasks;
using CQRS.Shared.Domain.Bus.Command;
using CQRS.Todo.Application.Item.Create;
using CQRS.Todo.Domain.Item;

namespace CQRS.Todo.Application.Item
{
    public class CreateItemCommandHandler : CommandHandler<CreateItemCommand>
    {
        private readonly ItemRepository _repository;

        public CreateItemCommandHandler(ItemRepository repository)
        {
            _repository = repository;
        }


        public async Task Handle(CreateItemCommand command)
        {
            _repository.Add(new Domain.Item.Item(command.Id, command.Name));
        }
    }
}