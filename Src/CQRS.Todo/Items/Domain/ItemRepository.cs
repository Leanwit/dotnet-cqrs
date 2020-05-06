using System;
using System.Threading.Tasks;

namespace CQRS.Todo.Items.Domain
{
    public interface ItemRepository
    {
        Task<Item> GetById(Guid id);
        Task Add(Item item);
    }
}