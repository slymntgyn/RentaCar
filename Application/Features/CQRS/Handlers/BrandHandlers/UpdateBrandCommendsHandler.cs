using Application.Features.CQRS.Commands.BrandCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommendsHandler
    {
        private readonly IRepository<Brand> _Repository;

        public UpdateBrandCommendsHandler(IRepository<Brand> repository)
        {
            _Repository = repository;
        }
        public async Task Handle(UpdateBrandCommands request)
        {
            Brand? brand = await _Repository.GetByIdAsync(request.Id);
            if (brand != null)
            {
                brand.Name = request.Name;
                await _Repository.UpdateAsync(brand);
            }
            else
            {
                Console.WriteLine("Bu id ye ait marka bulunamadı");
            }
        }
    }
}
