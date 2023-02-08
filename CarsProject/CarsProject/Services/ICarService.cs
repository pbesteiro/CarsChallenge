using CarsProject.ViewModels;

namespace CarsProject.Services
{
    public interface ICarService
    {
        CarViewModel Add(CarViewModel c);
        CarViewModel Edit(CarViewModel c);
        List<CarViewModel> Get();
        CarViewModel Get(int id);
        bool Remove(CarViewModel c);
    }
}