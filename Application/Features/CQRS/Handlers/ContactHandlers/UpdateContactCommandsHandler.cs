using Application.Features.CQRS.Commands.ContactCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandsHandler
    {
        private readonly IRepository<Contact> _Repository;

        public UpdateContactCommandsHandler(IRepository<Contact> repository)
        {
            _Repository = repository;
        }
        public async Task Handle(UpdateContactCommands request)
        {
            Contact? category = await _Repository.GetByIdAsync(request.Id);
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
