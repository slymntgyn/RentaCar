using Application.Features.Mediator.Commands.SocialMediaCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class RemoveSocialMediaCommandHandler : IRequestHandler<RemoveSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repository;

        public RemoveSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveSocialMediaCommand request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
            {
                throw new ArgumentException("Invalid social media ID.", nameof(request.Id));
            }
            SocialMedia? socialMedia = await _repository.GetByIdAsync(request.Id);
            if (socialMedia == null)
            {
                throw new KeyNotFoundException($"Social media with ID {request.Id} not found.");
            }
            await _repository.RemoveAsync(socialMedia.Id);
        }
    }
}
