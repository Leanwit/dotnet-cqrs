using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Todo.Domain.Item;

namespace CQRS.Todo.Infrastructure
{
    public class InMemoryItemRepository : ItemRepository
    {
        private List<Item> _context;

        public InMemoryItemRepository()
        {
            _context = new List<Item>();
        }

        public Task<Item> GetById(Guid id)
        {
            return Task.FromResult(_context.FirstOrDefault(x => x.Id.Equals(id)));
        }
        
        public Task Add(Item item)
        {
            _context.Add(item);
            return Task.CompletedTask;
        }
    }
}