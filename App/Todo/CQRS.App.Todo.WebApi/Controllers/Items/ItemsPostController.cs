using System;
using System.Threading.Tasks;
using CQRS.Todo.Items.Application.Create;
using CQRS.Todo.Shared.Domain.Bus.Commands;
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
            body = await JsonConvert.DeserializeObjectAsync(Convert.ToString(body));

            await _bus.Dispatch(new CreateItemCommand(new Guid(id), body["name"].ToString()));

            return StatusCode(201);
        }
    }
}