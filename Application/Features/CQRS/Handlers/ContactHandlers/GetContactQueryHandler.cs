using Application.Features.CQRS.Results.ContactResult;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _Repository;

        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            _Repository = repository;
        }
        public async Task<List<GetContactQueryResult>> Handle()
        {
            List<Contact> categories = await _Repository.GetAllAsync();
            return categories.Select(c => new GetContactQueryResult
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Subject = c.Subject,
                Message = c.Message,
                SendDate = c.SendDate
            }).ToList();
        }
    }
}
