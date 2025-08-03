using Application.Features.Mediator.Commands.FeatureCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class UpdateFutureCommandHandler : IRequestHandler<UpdateFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;

        public UpdateFutureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            Feature? feature = await _repository.GetByIdAsync(request.ID);
            if (feature != null)
            {
                feature.Name = request.Name;
                await _repository.UpdateAsync(feature);
            }
            else
            {
                throw new KeyNotFoundException($"Feature with ID {request.ID} not found.");
            }
        }
    }
}
