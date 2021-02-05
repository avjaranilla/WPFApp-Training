using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entities.Model;
using Entities.Interface;
using Microsoft.Extensions.Logging;

namespace WpfApp_Api.Controllers
{
    [Route("api/ListProperty")]
    [ApiController]
    public class ListPropertiesController : Controller
    {
        private readonly IListPropertyRepository _repository;

        private readonly ILogger<ListPropertiesController> _logger;

        public ListPropertiesController(IListPropertyRepository repository, ILogger<ListPropertiesController> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        //Get all list
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            _logger.LogInformation("Generate all list.");

            var data = await _repository.GetLists();
            int cnt = data.Count();
            _logger.LogInformation("Generated {cnt} list(s).",cnt );
            return Ok(data);
        }

        //Add new list
        [HttpPost("InsertList")]
        public async Task AddList(ListProperty ListProperty)
        {
            _logger.LogInformation("Add list, {ListName}, {ListDesc}.", ListProperty.ListName, ListProperty.ListDesc);
            //var arr[] = ListProperty;
            try
            {
                await _repository.InsertList(ListProperty);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Add new list, {ListProperty}. Failed. {ex}", ListProperty, ex);
            }
        }

        //Update particular list
        [HttpPut("UpdateList")]
        public async Task UpdateList(ListProperty ListProperty)
        {
            _logger.LogInformation("Update list, {ListID}, {ListName}, {ListDesc}.", ListProperty.ListID,ListProperty.ListName,ListProperty.ListDesc);
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateList(ListProperty);
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("Update list, {ListID},  {ListName} , {ListDesc}. Failed. {ex}",ListProperty.ListID, ListProperty.ListName, ListProperty.ListDesc,ex);

                }

            }
        }

        //Delete particular list
        [HttpDelete("DeleteList/{ListID}")]
        public async Task DeleteList(int ListID)
        {
            _logger.LogInformation("Delete list, {ListID}.", ListID);
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.DeleteList(ListID);
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("Delete list,  {ListID}. Failed. {ex}", ListID,ex);
                }
            }
        }
    }
}
