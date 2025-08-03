using Application.Features.Mediator.Queries.PricingQueries;
using Application.Features.Mediator.Results.PricingResult;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.PricingHandlers
{
    internal class GetPricingQueryHandler : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
    {
        private readonly IRepository<Pricing> repository;

        public GetPricingQueryHandler(IRepository<Pricing> request)
        {
            repository = request;
        }

        public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
        {
            List<Pricing> pricings = await repository.GetAllAsync();
            return pricings.Select(feature => new GetPricingQueryResult
            {
                Id = feature.Id,
                Name = feature.Name
            }).ToList();
        }
    }
}
