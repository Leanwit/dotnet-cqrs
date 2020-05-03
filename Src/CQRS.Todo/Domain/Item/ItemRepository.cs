using System;
using System.Threading.Tasks;

namespace CQRS.Todo.Domain.Item
{
    public interface ItemRepository
    {
        Task<Item> GetById(Guid id);
        Task Add(Item item);
    }
}