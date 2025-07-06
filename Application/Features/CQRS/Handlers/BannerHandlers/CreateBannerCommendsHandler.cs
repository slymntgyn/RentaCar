using Application.Features.CQRS.Commands.BannerCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class CreateBannerCommendsHandler
    {
        private readonly IRepository<Banner> _Repository;

        public CreateBannerCommendsHandler(IRepository<Banner> repository)
        {
            _Repository = repository;
        }
        public async Task Handle(CreateBannerCommands request)
        {
            await _Repository.CreateAsync(new Banner
            {
                Title = request.Title,
                Description = request.Description,
                VideoUrl = request.VideoUrl,
                VideoDescription = request.VideoDescription,
            });
        }
    }
}
