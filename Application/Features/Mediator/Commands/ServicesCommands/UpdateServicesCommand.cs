using MediatR;

namespace Application.Features.Mediator.Commands.ServicesCommands
{
    public class UpdateServicesCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal IconUrl { get; set; }
    }
}
