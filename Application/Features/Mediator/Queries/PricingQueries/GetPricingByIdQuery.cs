using Application.Features.Mediator.Results.PricingResult;
using MediatR;

namespace Application.Features.Mediator.Queries.PricingQueries
{
    public class GetPricingByIdQuery : IRequest<GetPricingByIdQueryResult>
    {
        public int Id { get; set; }
        public GetPricingByIdQuery(int id)
        {
            Id = id;
        }
    }

}
