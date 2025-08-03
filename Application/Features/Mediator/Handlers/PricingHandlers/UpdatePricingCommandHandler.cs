using Application.Features.Mediator.Commands.PricingCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.PricingHandlers
{
    public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;

        public UpdatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            Pricing? pricing = await _repository.GetByIdAsync(request.Id);
            if (pricing == null)
            {
                throw new KeyNotFoundException($"Pricing with ID {request.Id} not found.");
            }
            pricing.Name = request.Name;
            await _repository.UpdateAsync(pricing);
        }
    }
}
