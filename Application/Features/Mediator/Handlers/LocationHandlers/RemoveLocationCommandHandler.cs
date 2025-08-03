using Application.Features.Mediator.Commands.LocationCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.LocationHandlers
{
    public class RemoveLocationCommandHandler : IRequestHandler<RemoveLocationCommand>
    {
        private readonly IRepository<Location> repository;

        public RemoveLocationCommandHandler(IRepository<Location> repository)
        {
            this.repository = repository;
        }

        public Task Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
            {
                throw new ArgumentException("Invalid location ID.", nameof(request.Id));
            }
            return repository.RemoveAsync(request.Id);
        }
    }
}
