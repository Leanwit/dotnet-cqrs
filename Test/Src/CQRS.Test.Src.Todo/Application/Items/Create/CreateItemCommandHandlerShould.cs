using System;
using CQRS.Todo.Items.Application.Create;
using Xunit;

namespace CQRS.Test.Src.Todo.Application.Items.Create;

public class CreateItemCommandHandlerShould : ItemModuleUnitCase
{
    private readonly CreateItemCommandHandler _handler;
        
    public CreateItemCommandHandlerShould()
    {
        _handler = new CreateItemCommandHandler(Repository.Object);
    }
        
    [Fact]
    public void Create_a_valid_item()
    {
        var id = Guid.NewGuid();
        var name = "Create a new task";
            
        var item = new CQRS.Todo.Items.Domain.Item(id, name);
        var command = new CreateItemCommand(id, name);

        _handler.Handle(command);
            
        ShouldHaveSave(item);
    }
}