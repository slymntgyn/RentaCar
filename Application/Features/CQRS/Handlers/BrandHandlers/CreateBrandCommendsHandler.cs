using Application.Features.CQRS.Commands.BrandCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class CreateBrandCommendsHandler
    {
        private readonly IRepository<Brand> _Repository;

        public CreateBrandCommendsHandler(IRepository<Brand> repository)
        {
            _Repository = repository;
        }
        public async Task Handle(CreateBrandCommands request)
        {
            await _Repository.CreateAsync(new Brand
            {
                Name = request.Name,
                Cars = request.Cars
            });
        }
    }
}
