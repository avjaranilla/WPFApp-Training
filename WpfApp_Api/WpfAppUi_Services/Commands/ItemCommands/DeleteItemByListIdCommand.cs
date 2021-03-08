using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfAppUi_Entities.Interface;

namespace WpfAppUi_Services.Commands.ItemCommands
{
    public class DeleteItemByListIdCommand : IRequest<string>
    {
        public int _ListId;

        public DeleteItemByListIdCommand(int ListId)
        {
            this._ListId = ListId;
        }
    }


    public class DeleteItemByListIdCommandHandler : IRequestHandler<DeleteItemByListIdCommand, string>
    {
        private readonly IItemPropertyResponseObjRepo _repository;

        public DeleteItemByListIdCommandHandler(IItemPropertyResponseObjRepo repository)
        {
            this._repository = repository;
        }

        public async Task<string> Handle(DeleteItemByListIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _repository.DeleteItemByListID(request._ListId);
            return response;
        }
    }
}

