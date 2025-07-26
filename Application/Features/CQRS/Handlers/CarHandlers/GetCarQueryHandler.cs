using Application.Features.CQRS.Results.CarResult;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> repository;

        public GetCarQueryHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }
        public async Task<List<GetCarQueryResult>> Handle()
        {
            List<Car> banners = await repository.GetAllAsync();
            return banners.Select(b => new GetCarQueryResult
            {
                Id = b.Id,
                BrandId = b.BrandId,
                Model = b.Model,
                CoverImageUrl = b.CoverImageUrl,
                Km = b.Km,
                Transmission = b.Transmission,
                Seat = b.Seat,
                Lugage = b.Lugage,
                Fuel = b.Fuel,
                BigImageUrl = b.BigImageUrl
            }).ToList();
        }
    }
}
