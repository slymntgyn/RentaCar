using Application.Features.CQRS.Queries.BrandQueries;
using Application.Features.CQRS.Results.BrandResult;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler
    {
        private readonly IRepository<Brand> repository;

        public GetBrandByIdQueryHandler(IRepository<Brand> repository)
        {
            this.repository = repository;
        }
        public async Task<GetBrandByIdQueryResult?> Handle(GetBrandByIdQuery query)
        {
            Brand? brand = await repository.GetByIdAsync(query.id);
            return new GetBrandByIdQueryResult
            {
                Id = brand?.Id ?? 0,
                Name = brand?.Name
            };
        }
    }
}
