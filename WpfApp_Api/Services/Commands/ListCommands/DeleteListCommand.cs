using MediatR;
using Entities.Model;
using System.Threading.Tasks;
using System.Threading;
using Entities.Interface;
using Microsoft.Extensions.Logging;
using System;

namespace Services.Commands.ListCommands
{
    public class DeleteListCommand : IRequest
    {
        public  int ListID;
        public DeleteListCommand(int ListID)
        {
            this.ListID = ListID;
        }
    }

    public class DeleteListCommandHandler : IRequestHandler<DeleteListCommand>
    {
        //Dependency Injection Here
        private readonly IListPropertyRepository _repository;
        private readonly ILogger<DeleteListCommandHandler> _logger;

        public DeleteListCommandHandler(IListPropertyRepository _repository, ILogger<DeleteListCommandHandler> _logger)
        {
            this._repository = _repository;
            this._logger = _logger;
        }

        public async Task<Unit> Handle(DeleteListCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Delete list, {ListID}.", request.ListID);
            try
            {
                await _repository.DeleteList(request.ListID);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Delete list,  {ListID}. Failed. {ex}", request.ListID, ex);
            }
            return Unit.Value;
        }
    }
}
