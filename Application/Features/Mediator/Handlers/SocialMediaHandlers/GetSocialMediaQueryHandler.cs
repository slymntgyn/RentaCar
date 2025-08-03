using Application.Features.Mediator.Queries.SocialMediaQueries;
using Application.Features.Mediator.Results.SocialMediaResult;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
    {
        private readonly IRepository<SocialMedia> _socialMediaRepository;

        public GetSocialMediaQueryHandler(IRepository<SocialMedia> socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            return _socialMediaRepository.GetAllAsync()
                .ContinueWith(task => task.Result.Select(sm => new GetSocialMediaQueryResult
                {
                    Id = sm.Id,
                    Name = sm.Name,
                    IconUrl = sm.IconUrl,
                    Url = sm.Url,
                    IsActive = sm.IsActive

                }).ToList(), cancellationToken);
        }
    }
}
