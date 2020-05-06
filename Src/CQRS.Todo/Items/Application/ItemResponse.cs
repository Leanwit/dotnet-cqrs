using System;

namespace CQRS.Todo.Items.Application
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
        
        public override bool Equals(object obj)
        {
            if (this == obj) return true;

            var item = obj as ItemResponse;
            if (item == null) return false;

            return this.Id == item.Id && this.Name == item.Name && this.IsCompleted == item.IsCompleted;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id, this.Name, this.IsCompleted);
        }
    }
}