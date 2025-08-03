using MediatR;

namespace Application.Features.Mediator.Commands.PricingCommands
{
    public class UpdatePricingCommand : IRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }


    }
}
