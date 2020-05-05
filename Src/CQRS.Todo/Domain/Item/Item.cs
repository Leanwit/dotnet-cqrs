using System;

namespace CQRS.Todo.Domain.Item
{
    public class Item
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        
        public bool IsCompleted { get; private set; }

        public Item(Guid id, string name)
        {
            Id = id;
            Name = name;
            IsCompleted = false;
        }
    }
}