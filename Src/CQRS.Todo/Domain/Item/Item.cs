namespace CQRS.Todo.Domain.Item
{
    public class Item
    {
        public string Name { get; private set; }
        public bool IsCompleted { get; private set; }

        public Item(bool isCompleted, string name)
        {
            IsCompleted = isCompleted;
            Name = name;
        }
    }
}