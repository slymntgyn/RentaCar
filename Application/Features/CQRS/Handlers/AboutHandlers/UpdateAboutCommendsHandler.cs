using Application.Features.CQRS.Commands.AboutCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommendsHandler
    {
        private readonly IRepository<About> _Repository;
        public UpdateAboutCommendsHandler(IRepository<About> repository)
        {
            _Repository = repository;
        }
        public async Task Handle(UpdateAboutCommends request)
        {
            About? about = await _Repository.GetByIdAsync(request.Id);
            if (about != null)
            {
                about.Title = request.Title;
                about.Description = request.Description;
                about.ImageUrl = request.ImageUrl;
                await _Repository.UpdateAsync(about);
            }
            else
            {
                Console.WriteLine("Bu id ye ait about bulunamadı");
            }
        }
    }
}
