using Application.Features.CQRS.Commands.ContactCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class CreateContactCommandsHandler
    {
        private readonly IRepository<Contact> _Repository;

        public CreateContactCommandsHandler(IRepository<Contact> repository)
        {
            _Repository = repository;
        }
        public async Task Handle(CreateContactCommands request)
        {
            await _Repository.CreateAsync(new Contact
            {
                Name = request.Name,
                Email = request.Email,
                Subject = request.Subject,
                Message = request.Message,
                SendDate = DateTime.UtcNow
            });
        }
    }
}
