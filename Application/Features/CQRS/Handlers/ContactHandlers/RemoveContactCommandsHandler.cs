using Application.Features.CQRS.Commands.ContactCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class RemoveContactCommandsHandler
    {
        private readonly IRepository<Contact> _Repository;
        public RemoveContactCommandsHandler(IRepository<Contact> repository)
        {
            _Repository = repository;
        }
        public async Task Handle(RemoveContactCommands request)
        {
            Contact? category = await _Repository.GetByIdAsync(request.Id);
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
