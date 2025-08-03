using Application.Features.Mediator.Commands.FeatureCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class RemoveFeatureCommandHandler : IRequestHandler<RemoveFeatureCommand>
    {

        private readonly IRepository<Feature> _repository;

        public RemoveFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
        {
            Feature? value = await _repository.GetByIdAsync(request.Id);
            if (value != null)
            {
                await _repository.RemoveAsync(value.Id);
            }
            else
            {
                throw new KeyNotFoundException($"Feature with ID {request.Id} not found.");
            }
        }
    }
}
