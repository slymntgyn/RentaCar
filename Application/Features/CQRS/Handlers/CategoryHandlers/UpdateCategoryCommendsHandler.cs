using Application.Features.CQRS.Commands.CategoryCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommendsHandler
    {
        private readonly IRepository<Category> _Repository;
        public UpdateCategoryCommendsHandler(IRepository<Category> repository)
        {
            _Repository = repository;
        }
        public async Task Handle(UpdateCategoryCommands request)
        {
            Category? category = await _Repository.GetByIdAsync(request.Id);
            if (category != null)
            {
                category.Name = request.Name;
                await _Repository.UpdateAsync(category);
            }
            else
            {
                Console.WriteLine("Bu id ye ait kategori bulunamadı");
            }
        }
    }
}
