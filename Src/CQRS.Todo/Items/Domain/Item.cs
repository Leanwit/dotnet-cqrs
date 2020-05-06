using System;

namespace CQRS.Todo.Items.Domain
{
    public class Item 
    {
        public Guid Id { get; }
        public string Name { get; }
        
        public bool IsCompleted { get;}

        public Item(Guid id, string name)
        {
            Id = id;
            Name = name;
            IsCompleted = false;
        }
        
        public override bool Equals(object obj)
        {
            if (this == obj) return true;

            var item = obj as Item;
            if (item == null) return false;

            return this.Id == item.Id && this.Name == item.Name && this.IsCompleted == item.IsCompleted;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id, this.Name, this.IsCompleted);
        }
    }
}