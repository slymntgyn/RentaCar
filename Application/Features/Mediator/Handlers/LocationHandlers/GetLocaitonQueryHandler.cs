using Application.Features.Mediator.Queries.LocationQueries;
using Application.Features.Mediator.Results.LocationResult;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.LocationHandlers
{
    public class GetLocaitonQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
    {
        private readonly IRepository<Location> _repository;

        public GetLocaitonQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            List<Location> locations = await _repository.GetAllAsync();
            return locations.Select(feature => new GetLocationQueryResult
            {
                Id = feature.Id,
                Name = feature.Name
            }).ToList();
        }

    }
}
