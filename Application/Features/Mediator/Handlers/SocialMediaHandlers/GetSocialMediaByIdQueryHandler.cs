using Application.Features.Mediator.Queries.SocialMediaQueries;
using Application.Features.Mediator.Results.SocialMediaResult;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        private readonly IRepository<SocialMedia> repository;

        public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
        {
            this.repository = repository;
        }

        public Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            Task<SocialMedia?> socialMedia = repository.GetByIdAsync(request.Id);
            if (socialMedia == null)
            {
                throw new KeyNotFoundException($"Social media with ID {request.Id} not found.");
            }
            return Task.FromResult(new GetSocialMediaByIdQueryResult
            {
                Id = socialMedia.Result.Id,
                Name = socialMedia.Result.Name,
                IconUrl = socialMedia.Result.IconUrl,
                Url = socialMedia.Result.Url,
                IsActive = socialMedia.Result.IsActive
            });
        }
    }
}
