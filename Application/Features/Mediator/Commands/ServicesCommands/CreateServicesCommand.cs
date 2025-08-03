using MediatR;

namespace Application.Features.Mediator.Commands.ServicesCommands
{
    public class CreateServicesCommand : IRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal IconUrl { get; set; }
    }
}
