using Application.Features.CQRS.Commands.CategoryCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandsHandler
    {
        private readonly IRepository<Category> _Repository;

        public CreateCategoryCommandsHandler(IRepository<Category> repository)
        {
            _Repository = repository;
        }
        public async Task Handle(CreateCategoryCommands request)
        {
            await _Repository.CreateAsync(new Category
            {
                Name = request.Name
            });
        }
    }
}
