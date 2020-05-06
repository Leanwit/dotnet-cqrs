using System;
using System.Threading.Tasks;
using CQRS.Todo.Items.Application;
using CQRS.Todo.Items.Application.Find;
using CQRS.Todo.Items.Domain;
using Xunit;

namespace CQRS.Test.Src.Todo.Application.Items.Find
{
    public class FindItemQueryHandlerShould : ItemModuleUnitCase
    {
        private readonly FindItemQueryHandler _handler;

        public FindItemQueryHandlerShould()
        {
            _handler = new FindItemQueryHandler(this.Repository.Object);
        }

        [Fact]
        public async Task It_should_find_an_existing_item()
        {
            var id = Guid.NewGuid();
            var name = "Create a new task";

            var item = new Item(id, name);
            var itemResponse = new ItemResponse(id, name, false);
            var query = new FindItemQuery(id);

            this.ShouldSearch(item);
            Assert.Equal(itemResponse, await _handler.Handle(query));
        }
    }
}