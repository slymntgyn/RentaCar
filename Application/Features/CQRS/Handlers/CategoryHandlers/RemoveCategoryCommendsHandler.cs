using Application.Features.CQRS.Commands.CategoryCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommendsHandler
    {

        private readonly IRepository<Category> _Repository;

        public RemoveCategoryCommendsHandler(IRepository<Category> repository)
        {
            _Repository = repository;
        }

        public async Task Handle(RemoveCategoryCommands request)
        {
            Category? category = await _Repository.GetByIdAsync(request.Id);
            if (category != null)
            {
                await _Repository.RemoveAsync(category.Id);
            }
            else
            {
                Console.WriteLine("Bu id ye ait kategori bulunamadı");
            }
        }
    }
}
