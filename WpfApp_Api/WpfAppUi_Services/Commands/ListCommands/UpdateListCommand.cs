using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfAppUi_Entities.Entities;
using WpfAppUi_Entities.Interface;

namespace WpfAppUi_Services.Commands.ListCommands
{
    public class UpdateListCommand : IRequest<string>
    {
        public ListPropertyResponseObj _listPropertyResponseObj = new ListPropertyResponseObj();

        public UpdateListCommand(ListPropertyResponseObj listPropertyResponseObj)
        {
            this._listPropertyResponseObj = listPropertyResponseObj;
        }
        
    }

    public class UpdateListCommandHandler : IRequestHandler<UpdateListCommand, string>
    {
        private readonly IListPropertyResponseObjRepo _repository;

        public UpdateListCommandHandler(IListPropertyResponseObjRepo repository)
        {
            this._repository = repository;
        }

        public async Task<String> Handle(UpdateListCommand request, CancellationToken cancellationToken)
        {
            var response = await _repository.UpdateList(MapToDomain(request));
            return response;
        }

        private ListPropertyResponseObj MapToDomain(UpdateListCommand request)
        {
            return new ListPropertyResponseObj
            {
                ListID = request._listPropertyResponseObj.ListID,
                ListName = request._listPropertyResponseObj.ListName,
                ListDesc = request._listPropertyResponseObj.ListDesc
            };
        }
    }
}
