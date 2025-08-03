using Application.Features.Mediator.Queries.PricingQueries;
using Application.Features.Mediator.Results.PricingResult;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.PricingHandlers
{
    public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
    {
        private readonly IRepository<Pricing> _repository;

        public GetPricingByIdQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            Pricing? pricing = await _repository.GetByIdAsync(request.Id);
            if (pricing == null)
            {
                return new GetPricingByIdQueryResult();
            }
            return new GetPricingByIdQueryResult
            {
                Id = pricing.Id,
                Name = pricing.Name
            };
        }
    }
}
