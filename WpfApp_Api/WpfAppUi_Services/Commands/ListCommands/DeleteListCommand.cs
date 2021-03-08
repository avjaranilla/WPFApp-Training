using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfAppUi_Entities.Interface;

namespace WpfAppUi_Services.Commands.ListCommands
{
    public class DeleteListCommand : IRequest<string>
    {
        public int _ListId;
        public DeleteListCommand(int ListId)
        {
            this._ListId = ListId;
        }
    }

    public class DeleteListCommandHandler : IRequestHandler<DeleteListCommand, string>
    {
        //Dependency Injection Here
        private readonly IListPropertyResponseObjRepo _repository;

        public DeleteListCommandHandler(IListPropertyResponseObjRepo _repository)
        {
            this._repository = _repository;
        }

        public async Task<string> Handle(DeleteListCommand request, CancellationToken cancellationToken)
        {
            var response = await _repository.Deletelist(request._ListId);
            return response;
        }
    }
}