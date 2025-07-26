using Application.Features.CQRS.Queries.CategoryQueries;
using Application.Features.CQRS.Results.CategoryResult;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly IRepository<Category> repository;

        public GetCategoryByIdQueryHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }
        public async Task<GetByIdCategoryQueryResult?> Handle(GetCategoryByIdQuery query)
        {
            Category? category = await repository.GetByIdAsync(query.Id);
            return new GetByIdCategoryQueryResult
            {
                Id = category?.Id ?? 0,
                Name = category?.Name
            };
        }
    }
}
