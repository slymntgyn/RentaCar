using Application.Features.Mediator.Results.SocialMediaResult;
using MediatR;

namespace Application.Features.Mediator.Queries.SocialMediaQueries
{
    public class GetSocialMediaQuery : IRequest<List<GetSocialMediaQueryResult>>
    {
    }
}
