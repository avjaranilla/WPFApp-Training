using MediatR;
using Entities.Interface;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Services.Commands.ItemCommands
{
    public class DeleteItemByItemIDCommand : IRequest
    {
        public int ItemID;
        public DeleteItemByItemIDCommand(int ItemID)
        {
            this.ItemID = ItemID;
        }
    }


    public class DeleteItemByItemIDCommandHandler : IRequestHandler<DeleteItemByItemIDCommand>
    {
        private readonly IItemPropertyRepository _repository;
        private readonly ILogger<DeleteItemByItemIDCommandHandler> _logger;

        public DeleteItemByItemIDCommandHandler(IItemPropertyRepository _repository, ILogger<DeleteItemByItemIDCommandHandler> _logger)
        {
            this._repository = _repository;
            this._logger = _logger;
        }

        public async Task<Unit> Handle(DeleteItemByItemIDCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Delete Item, {ItemID}.", request.ItemID);
            try
            {
                await _repository.DeleteItemByID(request.ItemID);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Delete Item, {ItemID}. Failed", request.ItemID, ex);
            }
            return Unit.Value;
        }
    }
}
