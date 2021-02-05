using Entities.Interface;
using Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WpfApp_Api.Controllers
{
    [Route("api/ItemProperty")]
    [ApiController]
    public class ItemPropertiesController : Controller
    {
        private readonly IItemPropertyRepository _repository;

        private readonly ILogger<ListPropertiesController> _logger;

        public ItemPropertiesController(IItemPropertyRepository repository, ILogger<ListPropertiesController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
      
        //Get all items by ListID
        [HttpGet("GetItems")]
        public async Task<IActionResult> GetItem(int ListID)
        {
            _logger.LogInformation("Generating items with ListID: {ListID}.", ListID);
            var data = await _repository.GetItems(ListID);

            //if (data.Count() < 1)
            //    return NotFound("no result");
            //_logger.LogInformation($"Generated {data.Count()} item(s).");
            //return Ok(data);

            _logger.LogInformation("Generated {Count()} item(s).", data.Count());
            return Ok(data);
        }


        //Add new item
        [HttpPost("InsertItem")]
        public async Task InsertItem(ItemProperty ItemProperty)
        {
            try
            {
                _logger.LogInformation("Adding new item, ListID: {ListID}, ItemName: {ItemName}, ItemDesc: {ItemDesc}, ItemStatus: {ItemStatus}.", ItemProperty.ListID, ItemProperty.ItemName, ItemProperty.ItemDesc, ItemProperty.ItemStatus);
                await _repository.InsertItem(ItemProperty);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Adding new item, ListID: {ListID}, ItemName: {ItemName}, ItemDesc: {ItemDesc}, ItemStatus: {ItemStatus}. Failed. {ex}",ItemProperty.ListID, ItemProperty.ItemName, ItemProperty.ItemDesc, ItemProperty.ItemStatus, ex);
            }
        }

        //Update particular item
        [HttpPut("UpdateItem")]
        public async Task UpdateItem(ItemProperty ItemProperty)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _logger.LogInformation("Update item, ItemID: {ItemID}, ListID: {ListID}, ItemName: {ItemName}, ItemDesc: {ItemDesc}, ItemStatus: {ItemStatus}.", ItemProperty.ItemID, ItemProperty.ListID, ItemProperty.ItemName, ItemProperty.ItemDesc, ItemProperty.ItemStatus);
                    await _repository.UpdateItem(ItemProperty);
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("Update item, ItemID: {ItemID}, ListID: {ListID}, ItemName: {ItemName}, ItemDesc: {ItemDesc}, ItemStatus: {ItemStatus}. Failed. {ex}", ItemProperty.ItemID, ItemProperty.ListID, ItemProperty.ItemName, ItemProperty.ItemDesc, ItemProperty.ItemStatus, ex);

                }

            }
        }

        //Delete particular item
        [HttpDelete("DeleteByItemID/{ItemID}")]
        public async Task DeleteByItemID(int ItemID)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _logger.LogInformation("Delete item by ItemID, ItemID: {ItemID}.", ItemID);
                    await _repository.DeleteItemByID(ItemID);
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("Delete item by ItemID, ItemID: {ItemID}.Failed. {ex}", ItemID,ex);
                }
            }
        }

        //Delete particular item
        [HttpDelete("DeleteByListID/{ListID}")]
        public async Task DeleteByListID(int ListID)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _logger.LogInformation("Delete item by ListID, ListID: {ListID}.", ListID);

                    await _repository.DeleteItemByListID(ListID);
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("Delete item by ListID, ListID: {ListID}.Failed. {ex}", ListID,ex);
                }
            }
        }
    }
}
