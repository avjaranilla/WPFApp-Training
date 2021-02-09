using Entities.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Queries.ItemQueries;
using System;
using System.Linq;
using System.Threading.Tasks;
using Services.Queries.ItemQueries;
using Services.Commands.ItemCommands;

namespace WpfApp_Api.Controllers
{
    [Route("api/ItemProperty")]
    [ApiController]
    public class ItemPropertiesController : Controller
    {
        private readonly IMediator _mediator;

        public ItemPropertiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Get all items by ListID
        [HttpGet("GetItems")]
        public async Task<IActionResult> GetItem(int ListID)
        {
            var query = new GetItemQuery(ListID);
            var data = await _mediator.Send(query);
            return Ok(data);
        }


        //Add new item
        [HttpPost("InsertItem")]
        public async Task InsertItem(ItemProperty ItemProperty)
        {
            var command = new InsertItemCommand(ItemProperty);
            await _mediator.Send(command);
        }

        //Update particular item
        [HttpPut("UpdateItem")]
        public async Task UpdateItem(ItemProperty ItemProperty)
        {
            if (ModelState.IsValid)
            {
                var command = new UpdateItemCommand(ItemProperty);
                await _mediator.Send(command);
            }
        }

        //Delete particular item
        [HttpDelete("DeleteByItemID/{ItemID}")]
        public async Task DeleteByItemID(int ItemID)
        {
            if (ModelState.IsValid)
            {
                var command = new DeleteItemByItemIDCommand(ItemID);
                await _mediator.Send(command);
            }
        }

        //Delete particular item
        [HttpDelete("DeleteByListID/{ListID}")]
        public async Task DeleteByListID(int ListID)
        {
            if (ModelState.IsValid)
            {
                var command = new DeleteItemByListIDCommand(ListID);
                await _mediator.Send(command);
            }
        }
    }
}
