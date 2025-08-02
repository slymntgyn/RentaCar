using MediatR;

namespace Application.Features.Mediator.Commands.FeatureCommands
{
    public class UpdateFeatureCommand : IRequest
    {
        public int ID { get; set; }
        public string FeatureName { get; set; }
    }
}
