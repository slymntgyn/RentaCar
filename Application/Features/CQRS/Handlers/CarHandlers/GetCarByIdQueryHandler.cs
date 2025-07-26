using Application.Features.CQRS.Queries.CarQueries;
using Application.Features.CQRS.Results.CarResult;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }
        public async Task<GetCarByIdQueryResult?> Handle(GetCarByIdQuery query)
        {
            Car? brand = await repository.GetByIdAsync(query.id);
            return new GetCarByIdQueryResult
            {
                Id = brand?.Id ?? 0,
                BrandId = brand?.BrandId ?? 0,
                Model = brand?.Model,
                CoverImageUrl = brand?.CoverImageUrl,
                Km = brand?.Km,
                Transmission = brand?.Transmission,
                Seat = brand?.Seat,
                Lugage = brand?.Lugage,
                Fuel = brand?.Fuel,
                BigImageUrl = brand?.BigImageUrl

            };
        }
    }
}
