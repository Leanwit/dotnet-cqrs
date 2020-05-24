using CQRS.Todo.Items.Domain;
using Moq;

namespace CQRS.Test.Src.Todo.Application.Items
{
    public class ItemModuleUnitCase
    {
        protected readonly Mock<ItemRepository> Repository;

        public ItemModuleUnitCase()
        {
            this.Repository = new Mock<ItemRepository>();
        }

        protected void ShouldHaveSave(Item item)
        {
            this.Repository.Verify(x => x.Add(item), Times.AtLeastOnce());
        }

        protected void ShouldSearch(Item response)
        {
            this.Repository.Setup(x => x.GetById(response.Id)).ReturnsAsync(response);
        }
    }
}