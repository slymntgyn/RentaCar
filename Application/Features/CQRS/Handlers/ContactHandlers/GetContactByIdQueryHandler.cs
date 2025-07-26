using Application.Features.CQRS.Queries.ContactQueries;
using Application.Features.CQRS.Results.ContactResult;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _Repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _Repository = repository;
        }
        public async Task<GetByIdContactQueryResult?> Handle(GetContactByIdQuery query)
        {
            Contact? category = await _Repository.GetByIdAsync(query.Id);
            return new GetByIdContactQueryResult
            {
                Id = category?.Id ?? 0,
                Name = category?.Name,
                Email = category?.Email,
                Subject = category?.Subject,
                Message = category?.Message,
                SendDate = category?.SendDate ?? DateTime.MinValue
            };
        }
    }
}
