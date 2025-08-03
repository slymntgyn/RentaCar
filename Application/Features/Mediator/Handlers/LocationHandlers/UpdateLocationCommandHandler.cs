using Application.Features.Mediator.Commands.LocationCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.LocationHandlers
{
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
    {
        private readonly IRepository<Location> _repository;

        public UpdateLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
            {
                throw new ArgumentException("Invalid location ID.", nameof(request.Id));
            }
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ArgumentException("Location name cannot be empty.", nameof(request.Name));
            }
            return _repository.UpdateAsync(new Location
            {
                Id = request.Id,
                Name = request.Name
            });
        }
    }
}
