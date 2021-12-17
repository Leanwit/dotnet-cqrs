using System;
using CQRS.Todo.Shared.Domain.Bus.Commands;

namespace CQRS.Todo.Items.Application.Create;

public class CreateItemCommand : Command
{
    public Guid Id { get;}
    public string Name { get;}

    public CreateItemCommand(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}