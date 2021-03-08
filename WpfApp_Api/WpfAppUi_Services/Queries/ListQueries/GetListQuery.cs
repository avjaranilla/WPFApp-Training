using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WpfAppUi_Entities.Entities;
using WpfAppUi_Entities.Interface;

namespace WpfAppUi_Services
{
    public class GetListQuery : IRequest<IEnumerable<ListPropertyResponseObj>> 
    {
    
    }

    public class GetListQueryHandler : IRequestHandler<GetListQuery, IEnumerable<ListPropertyResponseObj>>
    {
        private readonly IListPropertyResponseObjRepo _repository;

        public GetListQueryHandler(IListPropertyResponseObjRepo repository)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<ListPropertyResponseObj>> Handle(GetListQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetLists();
            return data;
        }
    }
}

