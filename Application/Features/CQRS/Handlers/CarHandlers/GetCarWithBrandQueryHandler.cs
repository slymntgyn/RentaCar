using Application.Features.CQRS.Results.CarResult;
using Application.Interfaces.CarInterfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {

        private readonly ICarRepository repository;

        public GetCarWithBrandQueryHandler(ICarRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            List<Car> banners = repository.GetAllCarsListWithBrands();
            return banners.Select(b => new GetCarWithBrandQueryResult
            {
                BrandName = b.Brand?.Name,
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
