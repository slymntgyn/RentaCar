using Application.Features.CQRS.Results.BannerResult;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> repository;

        public GetBannerQueryHandler(IRepository<Banner> repository)
        {
            this.repository = repository;
        }
        public async Task<List<GetBannerQueryResult>> Handle()
        {
            List<Banner> banners = await repository.GetAllAsync();
            return banners.Select(b => new GetBannerQueryResult
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                VideoDescription = b.VideoDescription,
                VideoUrl = b.VideoUrl
            }).ToList();
        }
    }
}
