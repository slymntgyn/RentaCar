using Application.Features.Mediator.Queries.FeatureQueries;
using Application.Features.Mediator.Results.FeatureResult;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        private readonly IRepository<Feature> _repository;

        public GetFeatureByIdQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            Feature? feature = await _repository.GetByIdAsync(request.Id);
            if (feature == null) { }

            return new GetFeatureByIdQueryResult
            {
                Id = feature?.Id ?? 0,
                Name = feature?.Name ?? string.Empty

            };
        }
    }
}
