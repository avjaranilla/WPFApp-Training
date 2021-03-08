using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WpfAppUi_Entities.Entities;
using WpfAppUi_Entities.Interface;
using WpfAppUi_Infra.Repository;

namespace WpfAppUi_Services.Queries.ItemQueries
{
    public class GetItemQuery : IRequest<IEnumerable<ItemPropertyResponseObj>>
    {
        public int _ListId;

        public GetItemQuery(int ListId)
        {
            this._ListId = ListId;
        }
    }
    public class GetItemQueryHandler : IRequestHandler<GetItemQuery, IEnumerable<ItemPropertyResponseObj>>
    {
        private readonly IItemPropertyResponseObjRepo _repository;

        public GetItemQueryHandler(IItemPropertyResponseObjRepo repository)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<ItemPropertyResponseObj>> Handle(GetItemQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetItems(request._ListId);
            return data;
        }
    }
}
