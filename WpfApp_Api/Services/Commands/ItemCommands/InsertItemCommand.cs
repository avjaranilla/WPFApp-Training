using MediatR;
using Entities.Model;
using Entities.Interface;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Services.Commands.ItemCommands
{
    public class InsertItemCommand : IRequest
    {
        public ItemProperty itemProperty = new ItemProperty();
        public InsertItemCommand(ItemProperty itemProperty)
        {
            this.itemProperty = itemProperty;
        }
    }

    public class InsertItemCommandHandler : IRequestHandler<InsertItemCommand>
    {
        private readonly IItemPropertyRepository _repository;
        private readonly ILogger<InsertItemCommandHandler> _logger;

        public InsertItemCommandHandler(IItemPropertyRepository _repository, ILogger<InsertItemCommandHandler> _logger)
        {
            this._repository = _repository;
            this._logger = _logger;
        }

        public async Task<Unit> Handle(InsertItemCommand request, CancellationToken cancellationToken)
        {

            try
            {
                _logger.LogInformation("Add Item, {ListID} {ItemName}, {ItemDesc}, {Status}.",
                                request.itemProperty.ListID,
                                request.itemProperty.ItemName,
                                request.itemProperty.ItemDesc,
                                request.itemProperty.ItemStatus);

                await _repository.InsertItem(MapToDomain(request));
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Add Item, {ListID} {ItemName}, {ItemDesc}, {Status}, {ex}. Failed",
                               request.itemProperty.ListID,
                               request.itemProperty.ItemName,
                               request.itemProperty.ItemDesc,
                               request.itemProperty.ItemStatus, ex);
            }
            return Unit.Value;
        }

        private ItemProperty MapToDomain(InsertItemCommand request)
        {
            return new ItemProperty 
            { 
                ListID  = request.itemProperty.ListID,
                ItemName = request.itemProperty.ItemName,
                ItemDesc = request.itemProperty.ItemDesc,
                ItemStatus = request.itemProperty.ItemStatus 
            };
        }

    }
}
