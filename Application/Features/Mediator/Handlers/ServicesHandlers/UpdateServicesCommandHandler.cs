using Application.Features.Mediator.Commands.ServicesCommands;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.ServicesHandlers
{
    public class UpdateServicesCommandHandler : IRequestHandler<UpdateServicesCommand>
    {
        private readonly IRepository<Domain.Entities.Services> _repository;

        public UpdateServicesCommandHandler(IRepository<Domain.Entities.Services> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateServicesCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Services? pricing = await _repository.GetByIdAsync(request.Id);
            if (pricing == null)
            {
                throw new KeyNotFoundException($"Pricing with ID {request.Id} not found.");
            }
            pricing.Title = request.Title;
            pricing.Description = request.Description;
            pricing.IconUrl = request.IconUrl;

            await _repository.UpdateAsync(pricing);
        }
    }
}
