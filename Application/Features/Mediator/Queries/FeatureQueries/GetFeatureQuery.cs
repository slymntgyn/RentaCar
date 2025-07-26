using Application.Features.Mediator.Results.FeatureResult;
using MediatR;

namespace Application.Features.Mediator.Queries.FeatureQueries
{
    public class GetFeatureQuery : IRequest<List<GetFeatureQueryResult>>
    {
        public int Id { get; set; }
        public GetFeatureQuery(int id)
        {
            Id = id;
        }
    }
}
