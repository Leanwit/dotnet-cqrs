using CQRS.Todo.Items.Domain;
using Moq;

namespace CQRS.Test.Src.Todo.Application.Items;

public class ItemModuleUnitCase
{
    protected readonly Mock<ItemRepository> Repository;

    public ItemModuleUnitCase()
    {
        Repository = new Mock<ItemRepository>();
    }

    protected void ShouldHaveSave(Item item)
    {
        Repository.Verify(x => x.Add(item), Times.AtLeastOnce());
    }

    protected void ShouldSearch(Item response)
    {
        Repository.Setup(x => x.GetById(response.Id)).ReturnsAsync(response);
    }
}