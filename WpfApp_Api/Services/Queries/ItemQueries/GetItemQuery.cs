using MediatR;
using Entities.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Entities.Interface;
using Services.Queries.ListQueries;
using Microsoft.Extensions.Logging;

namespace Services.Queries.ItemQueries
{
    public class GetItemQuery : IRequest<List<ItemProperty>>
    {
        public int ListID;

        public GetItemQuery(int ListID)
        {
            this.ListID = ListID;
        }
    }

    public class GetItemQueryHandler : IRequestHandler<GetItemQuery, List<ItemProperty>>
    {
        private readonly IItemPropertyRepository _repository;
        private readonly ILogger<GetItemQueryHandler> _logger;

        public GetItemQueryHandler(IItemPropertyRepository _repository, ILogger<GetItemQueryHandler> _logger)
        {
            this._repository = _repository;
            this._logger = _logger;
        }

        public async Task<List<ItemProperty>> Handle(GetItemQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Generate all items.");
            var data = await _repository.GetItems(request.ListID);
            _logger.LogInformation("Generate {Count} items.", ((List<ItemProperty>)data).Count);
            return ((List<ItemProperty>)data);
        }
    }
}
