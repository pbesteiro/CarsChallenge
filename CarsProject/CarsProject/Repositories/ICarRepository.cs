using CarsProject.Models;

namespace CarsProject.Repositories
{
    public interface ICarRepository
    {
        Car Add(Car c);
        Car Edit(Car c);
        List<Car> Get();
        Car Get(int id);
        bool Remove(Car c);
    }
}