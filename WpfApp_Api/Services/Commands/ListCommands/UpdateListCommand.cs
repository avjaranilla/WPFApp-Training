using Entities.Interface;
using Entities.Model;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Commands.ListCommands    
{
    public class UpdateListCommand : IRequest
    {
        public ListProperty listProperty = new ListProperty();
        public UpdateListCommand(ListProperty listProperty)
        {
            this.listProperty = listProperty;
        }
    }

    public class UpdateListCommandHandler : IRequestHandler<UpdateListCommand>
    {

        //Dependency Injection Here
        private readonly IListPropertyRepository _repository;
        private readonly ILogger<UpdateListCommandHandler> _logger;

        public UpdateListCommandHandler(IListPropertyRepository _repository, ILogger<UpdateListCommandHandler> _logger)
        {
            this._repository = _repository;
            this._logger = _logger;
            
        }

        public async Task<Unit> Handle(UpdateListCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Update list, {ListID}, {ListName}, {ListDesc}.",
                request.listProperty.ListID,
                request.listProperty.ListName,
                request.listProperty.ListDesc);
            try
            {
                await _repository.UpdateList(MapToDomain(request));
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Update list, {ListID},  {ListName} , {ListDesc}. Failed. {ex}",
                    request.listProperty.ListID,
                    request.listProperty.ListName,
                    request.listProperty.ListDesc, ex);
            }
            return Unit.Value;
        }

        private ListProperty MapToDomain(UpdateListCommand request)
        {
            return new ListProperty { ListID = request.listProperty.ListID, ListName = request.listProperty.ListName, ListDesc = request.listProperty.ListDesc };
        }

    }
}
