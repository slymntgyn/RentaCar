using Application.Features.CQRS.Commands.BrandCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class RemoveBrandCommendsHandler
    {
        private readonly IRepository<Brand> _Repository;

        public RemoveBrandCommendsHandler(IRepository<Brand> repository)
        {
            _Repository = repository;
        }

        public async Task Handle(RemoveBrandCommands request)
        {
            Brand? banner = await _Repository.GetByIdAsync(request.id);
            if (banner != null)
            {
                await _Repository.RemoveAsync(banner.Id);
            }
            else
            {
                Console.WriteLine("Bu id ye ait banner bulunamadı");
            }
        }
    }
}
