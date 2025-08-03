using Application.Features.Mediator.Commands.PricingCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.PricingHandlers
{
    public class RemovePricingCommandHandler : IRequestHandler<RemovePricingCommand>
    {
        private readonly IRepository<Pricing> _pricingRepository;

        public RemovePricingCommandHandler(IRepository<Pricing> pricingRepository)
        {
            _pricingRepository = pricingRepository;
        }

        public async Task Handle(RemovePricingCommand request, CancellationToken cancellationToken)
        {
            Pricing? pricing = await _pricingRepository.GetByIdAsync(request.Id);
            if (pricing == null)
            {
                throw new KeyNotFoundException($"Pricing with ID {request.Id} not found.");
            }
            await _pricingRepository.RemoveAsync(pricing.Id);
        }
    }
}
