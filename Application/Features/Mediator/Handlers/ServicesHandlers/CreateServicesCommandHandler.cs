using Application.Features.Mediator.Commands.ServicesCommands;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.ServicesHandlers
{
    public class CreateServicesCommandHandler : IRequestHandler<CreateServicesCommand>
    {
        private readonly IRepository<Domain.Entities.Services> _repository;

        public CreateServicesCommandHandler(IRepository<Domain.Entities.Services> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateServicesCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Services service = new()
            {
                Title = request.Title,
                Description = request.Description,
                IconUrl = request.IconUrl
            };
            await _repository.CreateAsync(service);
        }
    }
}
