using Application.Features.Mediator.Queries.ServicesQueries;
using Application.Features.Mediator.Results.ServicesResult;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.ServicesHandlers
{
    public class GetServicesByIdHandler : IRequestHandler<GetServicesByIdQuery, GetServicesByIdQueryResult>
    {
        private readonly IRepository<Domain.Entities.Services> _repository;

        public GetServicesByIdHandler(IRepository<Domain.Entities.Services> repository)
        {
            _repository = repository;
        }

        public async Task<GetServicesByIdQueryResult> Handle(GetServicesByIdQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Services? service = await _repository.GetByIdAsync(request.Id);
            if (service == null)
            {
                return new GetServicesByIdQueryResult();
            }
            return new GetServicesByIdQueryResult
            {
                Id = service.Id,
                Title = service.Title,
                Description = service.Description,
                IconUrl = service.IconUrl
            };
        }
    }
}
