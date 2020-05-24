using System;
using CQRS.Todo.Shared.Domain.Bus;

namespace CQRS.Todo.Items.Application.Create
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