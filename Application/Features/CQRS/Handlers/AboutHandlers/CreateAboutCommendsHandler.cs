using Application.Features.CQRS.Commands.AboutCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class CreateAboutCommendsHandler
    {
        private readonly IRepository<About> _Repository;

        public CreateAboutCommendsHandler(IRepository<About> repository)
        {
            _Repository = repository;
        }

        public async Task Handle(CreateAboutCommends equest)
        {
            await _Repository.CreateAsync(new About
            {
                Title = equest.Title,
                Description = equest.Description,
                ImageUrl = equest.ImageUrl
            });
        }
    }
}
