using MediatR;

namespace Application.Features.Mediator.Commands.SocialMediaCommands
{
    public class UpdateSocialMediaCommand : IRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? IconUrl { get; set; }
        public string? Url { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
