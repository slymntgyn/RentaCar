using Application.Features.Mediator.Queries.ServicesQueries;
using Application.Features.Mediator.Results.ServicesResult;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.ServicesHandlers
{
    public class GetServicesQueryHandler : IRequestHandler<GetServicesQuery, List<GetServicesQueryResult>>
    {
        private readonly IRepository<Domain.Entities.Services> _repository;

        public GetServicesQueryHandler(IRepository<Domain.Entities.Services> repository)
        {
            _repository = repository;
        }

        public Task<List<GetServicesQueryResult>> Handle(GetServicesQuery request, CancellationToken cancellationToken)
        {
            Task<List<Domain.Entities.Services>> services = _repository.GetAllAsync();
            return services.ContinueWith(task =>
            {
                return task.Result.Select(service => new GetServicesQueryResult
                {
                    Id = service.Id,
                    Title = service.Title,
                    Description = service.Description,
                    IconUrl = service.IconUrl
                }).ToList();
            }, cancellationToken);
        }
    }
}
