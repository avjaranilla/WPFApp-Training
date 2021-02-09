using Entities.Interface;
using Entities.Model;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Commands.ListCommands
{
    public class InsertListCommand : IRequest
    {
        public ListProperty listProperty = new ListProperty();
        public InsertListCommand(ListProperty listProperty)
        {
            this.listProperty = listProperty;
        }
    }

    public class InsertListCommandHandler : IRequestHandler<InsertListCommand>
    {
        //Dependency Injection Here
        private readonly IListPropertyRepository _repository;
        private readonly ILogger<InsertListCommandHandler> _logger;

        public InsertListCommandHandler(IListPropertyRepository _repository, ILogger<InsertListCommandHandler> _logger)
        {
            this._repository = _repository;
            this._logger = _logger;
        }

        public async Task<Unit> Handle(InsertListCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Add list, {ListName}, {ListDesc}.", request.listProperty.ListName, request.listProperty.ListDesc);

            try
            {
                await _repository.InsertList(MapToDomain(request));
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Add new list, {ListName}, {ListDesc}. Failed. {ex}", request.listProperty.ListName, request.listProperty.ListDesc, ex);
            }
            return Unit.Value;
        }

        private ListProperty MapToDomain(InsertListCommand request)
        {
            return new ListProperty 
            {
                ListName = request.listProperty.ListName,
                ListDesc = request.listProperty.ListDesc 
            };
        }

    }
}
