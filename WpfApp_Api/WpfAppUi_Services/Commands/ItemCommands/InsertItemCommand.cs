using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfAppUi_Entities.Entities;
using WpfAppUi_Entities.Interface;

namespace WpfAppUi_Services.Commands.ItemCommands
{
    public class InsertItemCommand : IRequest<string>
    {
        public ItemPropertyResponseObj _itemPropertyResponseObj;

        public InsertItemCommand(ItemPropertyResponseObj itemPropertyResponseObj)
        {
            this._itemPropertyResponseObj = itemPropertyResponseObj;
        }
    }

    public class InsertItemCommandHandler : IRequestHandler<InsertItemCommand, string>
    {
        private readonly IItemPropertyResponseObjRepo _repository;

        public InsertItemCommandHandler(IItemPropertyResponseObjRepo repository)
        {
            this._repository = repository;
        }

        public async Task<string> Handle(InsertItemCommand request, CancellationToken cancellationToken)
        {
            var response = await _repository.InsertItem(MapToDomain(request));
            return response;
        }
        private ItemPropertyResponseObj MapToDomain(InsertItemCommand request)
        {
            return new ItemPropertyResponseObj
            {
                ListID = request._itemPropertyResponseObj.ListID,
                ItemName = request._itemPropertyResponseObj.ItemName,
                ItemDesc = request._itemPropertyResponseObj.ItemDesc
            };
        }
    }
}
