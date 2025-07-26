using Application.Features.CQRS.Results.CategoryResult;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly IRepository<Category> repository;

        public GetCategoryQueryHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }
        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            List<Category> categories = await repository.GetAllAsync();
            return categories.Select(c => new GetCategoryQueryResult
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }
    }
}
