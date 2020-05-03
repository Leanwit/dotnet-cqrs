using System;

namespace CQRS.Todo.Application.Item
{
    public class ItemResponse
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public bool IsCompleted { get; private set; }

        public ItemResponse(Guid id, string name, bool isCompleted)
        {
            Id = id;
            Name = name;
            IsCompleted = isCompleted;
        }
    }
}