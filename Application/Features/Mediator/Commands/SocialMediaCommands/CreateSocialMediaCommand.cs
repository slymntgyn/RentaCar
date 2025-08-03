using MediatR;

namespace Application.Features.Mediator.Commands.SocialMediaCommands
{
    public class CreateSocialMediaCommand : IRequest
    {
        public string? Name { get; set; }
        public string? IconUrl { get; set; }
        public string? Url { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
