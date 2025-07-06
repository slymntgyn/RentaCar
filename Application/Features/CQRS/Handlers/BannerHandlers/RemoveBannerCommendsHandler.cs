using Application.Features.CQRS.Commands.BannerCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class RemoveBannerCommendsHandler
    {
        private readonly IRepository<Banner> _Repository;

        public RemoveBannerCommendsHandler(IRepository<Banner> repository)
        {
            _Repository = repository;
        }
        public async Task Handle(RemoveBannerCommands request)
        {
            Banner? banner = await _Repository.GetByIdAsync(request.Id);
            if (banner != null)
            {
                await _Repository.RemoveAsync(banner.Id);
            }
            else
            {
                Console.WriteLine("Bu id ye ait banner bulunamadı");
            }
        }
    }
}
