using Application.Features.CQRS.Commands.CarCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class RemoveCarCommendsHandler
    {
        private readonly IRepository<Car> _Repository;

        public RemoveCarCommendsHandler(IRepository<Car> repository)
        {
            _Repository = repository;
        }

        public async Task Handle(RemoveCarCommands request)
        {
            Car? banner = await _Repository.GetByIdAsync(request.Id);
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
