using Application.Features.Mediator.Commands.SocialMediaCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repository;

        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
            {
                throw new ArgumentException("Invalid social media ID.", nameof(request.Id));
            }
            SocialMedia? socialMedia = _repository.GetByIdAsync(request.Id).Result;
            if (socialMedia == null)
            {
                throw new KeyNotFoundException($"Social media with ID {request.Id} not found.");
            }
            socialMedia.Name = request.Name;
            socialMedia.IconUrl = request.IconUrl;
            socialMedia.Url = request.Url;
            socialMedia.IsActive = request.IsActive;
            return _repository.UpdateAsync(socialMedia);
        }
    }
}
