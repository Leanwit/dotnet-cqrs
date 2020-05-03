using System.Threading.Tasks;
using CQRS.Shared.Domain.Bus.Query;
using CQRS.Todo.Domain.Item;

namespace CQRS.Todo.Application.Item.Find
{
    public class FindItemQueryHandler : QueryHandler<FindItemQuery, ItemResponse>
    {
        private readonly ItemRepository _repository;

        public FindItemQueryHandler(ItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<ItemResponse> Handle(FindItemQuery query)
        {
            Domain.Item.Item item = await _repository.GetById(query.Id);
            
            return new ItemResponse(item.Id, item.Name, item.IsCompleted);
        }
    }
}