using Application.Features.Mediator.Results.LocationResult;
using MediatR;

namespace Application.Features.Mediator.Queries.LocationQueries
{

    public class GetLocationQuery : IRequest<List<GetLocationQueryResult>>
    {
    }
}
