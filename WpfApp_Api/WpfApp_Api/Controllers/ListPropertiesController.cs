using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entities.Model;
using MediatR;
using Services.Commands.ListCommands;
using Services.Queries.ListQueries;

namespace WpfApp_Api.Controllers
{
    [Route("api/ListProperty")]
    [ApiController]
    public class ListPropertiesController : Controller
    {
        private readonly IMediator _mediator;

        public ListPropertiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Get all list
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var query = new GetListQuery();
            var data = await _mediator.Send(query);
            return Ok(data);
        }

        //Add new list
        [HttpPost("InsertList")]
        public async Task AddList(ListProperty ListProperty)
        {
            var command = new InsertListCommand(ListProperty);
            await _mediator.Send(command);
        }

        //Update particular list
        [HttpPut("UpdateList")]
        public async Task UpdateList(ListProperty ListProperty)
        {
            if (ModelState.IsValid)
            {
                var command = new UpdateListCommand(ListProperty);
                await _mediator.Send(command);
            }
        }

        //Delete particular list
        [HttpDelete("DeleteList/{ListID}")]
        public async Task DeleteList(int ListID)
        {
            if (ModelState.IsValid)
            {
                var command = new DeleteListCommand(ListID);
                await _mediator.Send(command);
            }
        }
    }
}
