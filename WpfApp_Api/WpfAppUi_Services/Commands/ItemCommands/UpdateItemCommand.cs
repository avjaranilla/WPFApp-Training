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
    public class UpdateItemCommand : IRequest<string>
    {
        public ItemPropertyResponseObj _itemPropertyResponseObj;

        public UpdateItemCommand(ItemPropertyResponseObj itemPropertyResponseObj)
        {
            this._itemPropertyResponseObj = itemPropertyResponseObj;
        }
    }

    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, string>
    {
        private readonly IItemPropertyResponseObjRepo _repository;

        public UpdateItemCommandHandler(IItemPropertyResponseObjRepo repository)
        {
            this._repository = repository;
        }

        public async Task<string> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var response = await _repository.UpdateItem(MapToDomain(request));
            return response;
        }

        private ItemPropertyResponseObj MapToDomain(UpdateItemCommand request)
        {
            return new ItemPropertyResponseObj
            {
                ItemID = request._itemPropertyResponseObj.ItemID,
                ListID = request._itemPropertyResponseObj.ListID,
                ItemName = request._itemPropertyResponseObj.ItemName,
                ItemDesc = request._itemPropertyResponseObj.ItemDesc
            };
        }
    }
}
