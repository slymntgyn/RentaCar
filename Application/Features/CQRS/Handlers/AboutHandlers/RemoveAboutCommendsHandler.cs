using Application.Features.CQRS.Commands.AboutCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class RemoveAboutCommendsHandler
    {
        private readonly IRepository<About> _Repository;
        public RemoveAboutCommendsHandler(IRepository<About> repository)
        {
            _Repository = repository;
        }
        public async Task Handle(RemoveAboutCommends request)
        {
            About? about = await _Repository.GetByIdAsync(request.Id);
            if (about != null)
            {
                await _Repository.RemoveAsync(about.Id);
            }
            else
            {
                Console.WriteLine("Bu id ye ait about bulunamadı");
            }
        }
    }
}
