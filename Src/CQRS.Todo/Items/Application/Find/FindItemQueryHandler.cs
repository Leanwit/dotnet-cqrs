using System.Threading.Tasks;
using CQRS.Todo.Items.Domain;

namespace CQRS.Todo.Items.Application.Find
{
    public class FindItemQueryHandler : Shared.Domain.Bus.QueryHandler<FindItemQuery, ItemResponse>
    {
        private readonly ItemRepository _repository;

        public FindItemQueryHandler(ItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<ItemResponse> Handle(FindItemQuery query)
        {
            Item item = await _repository.GetById(query.Id);

            return new ItemResponse(item.Id, item.Name, item.IsCompleted);
        }
    }
}