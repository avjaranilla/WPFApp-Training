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
    public class InsertListCommand : IRequest<string>
    {
        public ListPropertyResponseObj _listPropertyResponseObj = new ListPropertyResponseObj();

        public InsertListCommand(ListPropertyResponseObj listPropertyResponseObj)
        {
            this._listPropertyResponseObj = listPropertyResponseObj;
        }
    }

    public class InsertListCommandHandler : IRequestHandler<InsertListCommand, string>
    {
        private readonly IListPropertyResponseObjRepo _repository;

        public InsertListCommandHandler(IListPropertyResponseObjRepo repository)
        {
            this._repository = repository;
        }

        public async Task<string> Handle(InsertListCommand request, CancellationToken cancellationToken)
        {
            var response = await _repository.InsertList(MapToDomain(request));
            return response;
        }

        private ListPropertyResponseObj MapToDomain(InsertListCommand request)
        {
            return new ListPropertyResponseObj
            {
                ListName = request._listPropertyResponseObj.ListName,
                ListDesc = request._listPropertyResponseObj.ListDesc
            };
        }
    }
}
