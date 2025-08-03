using Application.Features.Mediator.Results.ServicesResult;
using MediatR;

namespace Application.Features.Mediator.Queries.ServicesQueries
{
    public class GetServicesByIdQuery : IRequest<GetServicesByIdQueryResult>
    {
        public int Id { get; set; }
        public GetServicesByIdQuery(int id)
        {
            Id = id;
        }
    }
}
