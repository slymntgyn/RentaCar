using Application.Features.Mediator.Commands.ServicesCommands;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.ServicesHandlers
{
    public class RemoveServicesCommandHandler : IRequestHandler<RemoveServicesCommand>
    {
        private readonly IRepository<Domain.Entities.Services> _repository;

        public RemoveServicesCommandHandler(IRepository<Domain.Entities.Services> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveServicesCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Services service = await _repository.GetByIdAsync(request.Id);
            if (service != null)
            {
                _repository.RemoveAsync(service.Id);
            }
        }
    }

}
