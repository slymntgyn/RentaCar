using Application.Features.Mediator.Queries.FeatureQueries;
using Application.Features.Mediator.Results.FeatureResult;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        private readonly IRepository<Feature> _repository;

        public GetFeatureQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            List<Feature> features = await _repository.GetAllAsync();

            return features.Select(feature => new GetFeatureQueryResult
            {
                Id = feature.Id,
                Name = feature.Name
            }).ToList();
        }

    }
}
