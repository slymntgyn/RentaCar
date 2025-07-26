using Domain.Entities;

namespace Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        List<Car> GetAllCarsListWithBrands();
    }
}
