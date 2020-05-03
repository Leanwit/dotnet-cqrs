using System;
using CQRS.Shared.Domain.Bus.Command;

namespace CQRS.Todo.Application.Item.Create
{
    public class CreateItemCommand : Command
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public CreateItemCommand(Guid id, string name) 
        {
            Id = id;
            Name = name;
        }
    }
}