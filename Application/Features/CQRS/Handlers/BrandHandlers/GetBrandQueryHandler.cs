using Application.Features.CQRS.Results.BrandResult;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandQueryHandler
    {
        private readonly IRepository<Brand> repository;

        public GetBrandQueryHandler(IRepository<Brand> repository)
        {
            this.repository = repository;
        }
        public async Task<List<GetBrandQueryResult>> Handle()
        {
            List<Brand> banners = await repository.GetAllAsync();
            return banners.Select(b => new GetBrandQueryResult
            {
                Id = b.Id,
                Name = b.Name,
                Cars = b.Cars
            }).ToList();
        }
    }
}
