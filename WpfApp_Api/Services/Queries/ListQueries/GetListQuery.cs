using Entities.Interface;
using Entities.Model;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Services.Queries.ListQueries
{
    public class GetListQuery : IRequest<List<ListProperty>> { }

    public class GetListQueryHandler : IRequestHandler<GetListQuery, List<ListProperty>>
    {

        private readonly IListPropertyRepository _repository;
        private readonly ILogger<GetListQueryHandler> _logger;

        public GetListQueryHandler(IListPropertyRepository _repository, ILogger<GetListQueryHandler> _logger)
        {
            this._repository = _repository;
            this._logger = _logger;
        }

        public async Task<List<ListProperty>> Handle(GetListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Generate all list.");
            var data = await _repository.GetLists();
            _logger.LogInformation("Generate {Count} list.", ((List<ListProperty>)data).Count);
            return ((List<ListProperty>)data);
        }
    }

}