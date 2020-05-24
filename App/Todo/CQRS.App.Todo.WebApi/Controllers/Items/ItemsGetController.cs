

using System;
using System.Threading.Tasks;
using CQRS.Todo.Items.Application;
using CQRS.Todo.Items.Application.Find;
using CQRS.Todo.Shared.Domain.Bus;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.App.WebApi.Controllers.Items
{
    [Route("Items")]
    public class ItemsGetController : Controller
    {
        private readonly QueryBus _bus;

        public ItemsGetController(QueryBus bus)
        {
            _bus = bus;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index(string id)
        {

            var something = await this._bus.Send<ItemResponse>(new FindItemQuery(new Guid(id)));

            return StatusCode(201, something);
        }
    }
}