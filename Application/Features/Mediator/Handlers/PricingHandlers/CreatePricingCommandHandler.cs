using Application.Features.Mediator.Commands.PricingCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.PricingHandlers
{
    internal class CreatePricingCommandHandler : IRequestHandler<CreatePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;

        public CreatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public Task Handle(CreatePricingCommand request, CancellationToken cancellationToken)
        {
            Pricing pricing = new()
            {
                Name = request.Name

            };
            _repository.CreateAsync(pricing);
            return Task.CompletedTask;
        }
    }
}
