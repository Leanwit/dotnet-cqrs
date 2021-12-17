using System.Threading.Tasks;
using CQRS.Todo.Items.Domain;
using CQRS.Todo.Shared.Domain.Bus.Commands;

namespace CQRS.Todo.Items.Application.Create;
    public class CreateItemCommandHandler : CommandHandler<CreateItemCommand>
    {
        private readonly ItemRepository _repository;

        public CreateItemCommandHandler(ItemRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateItemCommand command)
        {
            await _repository.Add(new Item(command.Id, command.Name));
        }
    }
