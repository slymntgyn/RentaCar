using Application.Features.CQRS.Commands.CarCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandsHandler
    {
        private readonly IRepository<Car> _Repository;

        public CreateCarCommandsHandler(IRepository<Car> repository)
        {
            _Repository = repository;
        }
        public async Task Handle(CreateCarCommands request)
        {
            await _Repository.CreateAsync(new Car
            {
                BrandId = request.BrandId,
                Model = request.Model,
                CoverImageUrl = request.CoverImageUrl,
                Km = request.Km,
                Transmission = request.Transmission,
                Seat = request.Seat,
                Lugage = request.Lugage,
                Fuel = request.Fuel,
                BigImageUrl = request.BigImageUrl
            });
        }
    }
}
