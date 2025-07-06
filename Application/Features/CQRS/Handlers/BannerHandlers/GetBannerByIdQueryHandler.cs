using Application.Features.CQRS.Queries.BannerQueries;
using Application.Features.CQRS.Results.BannerResult;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            this.repository = repository;
        }
        public async Task<GetBannerByIdQueryResult?> Handle(GetBannerByIdQuery query)
        {
            Banner? banner = await repository.GetByIdAsync(query.Id);
            return new GetBannerByIdQueryResult
            {
                Id = banner?.Id ?? 0,
                Title = banner?.Title,
                Description = banner?.Description,
                VideoDescription = banner?.VideoDescription,
                VideoUrl = banner?.VideoUrl
            };
        }
    }
}
