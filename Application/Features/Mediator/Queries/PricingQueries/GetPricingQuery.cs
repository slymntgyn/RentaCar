using Application.Features.Mediator.Results.PricingResult;
using MediatR;

namespace Application.Features.Mediator.Queries.PricingQueries
{
    public class GetPricingQuery : IRequest<List<GetPricingQueryResult>>
    {

    }
}
