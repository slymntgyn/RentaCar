using Application.Features.Mediator.Results.FeatureResult;
using MediatR;

namespace Application.Features.Mediator.Queries.FeatureQueries
{
    public class GetFeatureByIdQuery : IRequest<GetFeatureByIdQueryResult>
    {
        public int Id { get; set; }
        public GetFeatureByIdQuery(int id)
        {
            Id = id;
        }
    }
}
