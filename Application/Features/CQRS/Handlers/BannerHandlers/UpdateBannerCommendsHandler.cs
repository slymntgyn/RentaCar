using Application.Features.CQRS.Commands.BannerCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommendsHandler
    {
        private readonly IRepository<Banner> _Repository;

        public UpdateBannerCommendsHandler(IRepository<Banner> repository)
        {
            _Repository = repository;
        }
        public async Task Handle(UpdateBannerCommands request)
        {
            Banner? banner = await _Repository.GetByIdAsync(request.Id);
            if (banner != null)
            {
                banner.Title = request.Title;
                banner.Description = request.Description;
                banner.VideoUrl = request.VideoUrl;
                banner.VideoDescription = request.VideoDescription;
                await _Repository.UpdateAsync(banner);
            }
            else
            {
                Console.WriteLine("Bu id ye ait banner bulunamadı");
            }
        }
    }
}
