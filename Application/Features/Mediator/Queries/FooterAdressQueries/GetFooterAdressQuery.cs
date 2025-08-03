using Application.Features.Mediator.Results.FooterAdressResult;
using MediatR;

namespace Application.Features.Mediator.Queries.FooterAdressQueries
{
    public class GetFooterAdressQuery : IRequest<List<GetFooterAdressQueryResult>>
    {
    }
}
