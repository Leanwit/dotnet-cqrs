using CQRS.Shared.Domain.Bus.Command;

namespace CQRS.Todo.Application.Item
{
    public class CreateItemCommand : Command
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        public CreateItemCommand(string name, string id)
        {
            Name = name;
            Id = id;
        }
    }
}