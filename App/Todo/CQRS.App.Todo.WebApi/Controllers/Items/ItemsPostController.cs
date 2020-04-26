using System;
using System.Threading.Tasks;
using CQRS.Shared.Domain.Bus.Command;
using CQRS.Todo.Application.Item;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CQRS.App.WebApi.Controllers.Items
{
    [Route("Items")]
    public class ItemsPostController : Controller
    {
        private readonly CommandBus _bus;

        public ItemsPostController(CommandBus bus)
        {
            _bus = bus;
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Index(string id, [FromBody] dynamic body)
        {
            body = JsonConvert.DeserializeObject(Convert.ToString(body));

            await this._bus.Dispatch(new CreateItemCommand(id, body["name"].ToString()));

            return StatusCode(201);
        }
    }
}