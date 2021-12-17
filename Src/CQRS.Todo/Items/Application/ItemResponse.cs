using System;

namespace CQRS.Todo.Items.Application;

public class ItemResponse
{
    public Guid Id { get; }
    public string Name { get; }
    public bool IsCompleted { get; }

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

        return Id == item.Id && Name == item.Name && IsCompleted == item.IsCompleted;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, IsCompleted);
    }
}