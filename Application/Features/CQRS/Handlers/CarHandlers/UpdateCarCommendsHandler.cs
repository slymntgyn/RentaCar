using Application.Features.CQRS.Commands.CarCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommendsHandler
    {
        private readonly IRepository<Car> _Repository;

        public UpdateCarCommendsHandler(IRepository<Car> repository)
        {
            _Repository = repository;
        }
        public async Task Handle(UpdateCarCommands request)
        {
            Car? brand = await _Repository.GetByIdAsync(request.Id);
            if (brand != null)
            {
                brand.BrandId = request.BrandId;
                brand.Model = request.Model;
                brand.CoverImageUrl = request.CoverImageUrl;
                brand.Km = request.Km;
                brand.Transmission = request.Transmission;
                brand.Seat = request.Seat;
                brand.Lugage = request.Lugage;
                brand.Fuel = request.Fuel;
                brand.BigImageUrl = request.BigImageUrl;
                await _Repository.UpdateAsync(brand);
            }
            else
            {
                Console.WriteLine("Bu id ye ait marka bulunamadı");
            }
        }
    }
}
