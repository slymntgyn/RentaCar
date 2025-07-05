using Application.Features.CQRS.Queries.AboutQueries;
using Application.Features.CQRS.Results.AboutResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> repository;
        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            this.repository = repository;
        }
        public async Task<GetAboutByIdQueryResult?> Handle(GetAboutByIdQuery query)
        {
            About? about = await repository.GetByIdAsync(query.Id);
            return new GetAboutByIdQueryResult
            {
                Id = about?.Id ?? 0,
                Title = about?.Title,
                Description = about?.Description,
                ImageUrl = about?.ImageUrl
            };

        }
    }
}