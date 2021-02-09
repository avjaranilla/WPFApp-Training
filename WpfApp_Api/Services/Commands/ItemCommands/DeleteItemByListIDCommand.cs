using MediatR;
using Entities.Interface;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;
using System;


namespace Services.Commands.ItemCommands
{
    public class DeleteItemByListIDCommand : IRequest
    {
        public int ListID;
        public DeleteItemByListIDCommand(int ListID)
        {
            this.ListID = ListID;
        }       
    }

    public class DeleteItemByListIDCommandHandler : IRequestHandler<DeleteItemByListIDCommand>
    {
        private readonly IItemPropertyRepository _repository;
        private readonly ILogger<DeleteItemByListIDCommandHandler> _logger;

        public DeleteItemByListIDCommandHandler(IItemPropertyRepository _repository, ILogger<DeleteItemByListIDCommandHandler> _logger)
        {
            this._repository = _repository;
            this._logger = _logger;
        }

        public async Task<Unit> Handle(DeleteItemByListIDCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Delete Items, {ListID}.", request.ListID);
            try
            {
                await _repository.DeleteItemByListID(request.ListID);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Delete Item, {ListID}. Failed", request.ListID, ex);
            }
            return Unit.Value;
        }
    }
}
