using Application.Features.Mediator.Commands.SocialMediaCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _socialMediaRepository;

        public CreateSocialMediaCommandHandler(IRepository<SocialMedia> socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            SocialMedia socialMedia = new()
            {
                Name = request.Name,
                IconUrl = request.IconUrl,
                Url = request.Url,
                IsActive = request.IsActive
            };
            await _socialMediaRepository.CreateAsync(socialMedia);
        }
    }
}
