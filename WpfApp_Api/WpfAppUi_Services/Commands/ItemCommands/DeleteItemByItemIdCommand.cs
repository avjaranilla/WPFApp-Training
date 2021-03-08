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
    public class DeleteItemByItemIdCommand : IRequest<string>
    {
        public int _ItemId;

        public DeleteItemByItemIdCommand(int ItemId)
        {
            this._ItemId = ItemId;
        }
    }


    public class DeleteItemByItemIdCommandHandler : IRequestHandler<DeleteItemByItemIdCommand, string>
    {
        private readonly IItemPropertyResponseObjRepo _repository;

        public DeleteItemByItemIdCommandHandler(IItemPropertyResponseObjRepo repository)
        {
            this._repository = repository;
        }

        public async Task<string> Handle(DeleteItemByItemIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _repository.DeleteItemByItemID(request._ItemId);
            return response;
        }
    }
}
