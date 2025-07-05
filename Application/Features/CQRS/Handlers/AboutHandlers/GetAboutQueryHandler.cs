using Application.Features.CQRS.Results.AboutResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler
    {
        private readonly IRepository<About> repository;

        public GetAboutQueryHandler(IRepository<About> repository)
        {
            this.repository = repository;
        }
        public async Task<List<GetAboutByIdQueryResult>> Handle()
        {
            List<About> abouts = await repository.GetAllAsync();
            return abouts.Select(a => new GetAboutByIdQueryResult
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description,
                ImageUrl = a.ImageUrl
            }).ToList();
        }
    }
}