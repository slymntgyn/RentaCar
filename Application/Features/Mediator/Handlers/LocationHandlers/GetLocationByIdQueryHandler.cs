using Application.Features.Mediator.Queries.LocationQueries;
using Application.Features.Mediator.Results.LocationResult;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.LocationHandlers
{
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    {
        private readonly IRepository<Location> _repository;

        public GetLocationByIdQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(async () =>
            {
                Location? location = await _repository.GetByIdAsync(request.Id);
                if (location == null)
                {
                    return new GetLocationByIdQueryResult();
                }
                return new GetLocationByIdQueryResult
                {
                    Id = location.Id,
                    Name = location.Name
                };
            }, cancellationToken);
        }
    }
}
