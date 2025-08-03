using Application.Features.Mediator.Results.ServicesResult;
using MediatR;

namespace Application.Features.Mediator.Queries.ServicesQueries
{
    public class GetServicesQuery : IRequest<List<GetServicesQueryResult>>
    {
    }
}
