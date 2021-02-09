using MediatR;
using Entities.Model;
using System.Threading.Tasks;
using System.Threading;
using Entities.Interface;
using Microsoft.Extensions.Logging;
using System;

namespace Services.Commands.ItemCommands
{
    public class UpdateItemCommand : IRequest
    {
        public ItemProperty itemProperty = new ItemProperty();
        public UpdateItemCommand(ItemProperty itemProperty)
        {
            this.itemProperty = itemProperty;      
        }
    }

    public class UpdateItemCommandHander : IRequestHandler<UpdateItemCommand>
    {
        private readonly IItemPropertyRepository _repository;
        private readonly ILogger<UpdateItemCommandHander> _logger;

        public UpdateItemCommandHander(IItemPropertyRepository _repository, ILogger<UpdateItemCommandHander> _logger)
        {
            this._repository = _repository;
            this._logger = _logger;
        }

        public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Update Item, {ListID} {ItemName}, {ItemDesc}, {Status}.",
                                request.itemProperty.ListID,
                                request.itemProperty.ItemName,
                                request.itemProperty.ItemDesc,
                                request.itemProperty.ItemStatus);


                await _repository.UpdateItem(MapToDomain(request));
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Update Item, {ListID} {ItemName}, {ItemDesc}, {Status}, {ex}. Failed",
                               request.itemProperty.ListID,
                               request.itemProperty.ItemName,
                               request.itemProperty.ItemDesc,
                               request.itemProperty.ItemStatus, ex);
            }
            return Unit.Value;
        }

        private ItemProperty MapToDomain(UpdateItemCommand request)
        {
            return new ItemProperty
            {
                ListID = request.itemProperty.ListID,
                ItemName = request.itemProperty.ItemName,
                ItemDesc = request.itemProperty.ItemDesc,
                ItemStatus = request.itemProperty.ItemStatus
            };
        }

    }
}
