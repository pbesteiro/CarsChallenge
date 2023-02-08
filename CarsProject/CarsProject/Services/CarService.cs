using CarsProject.Models;
using CarsProject.Repositories;
using CarsProject.ViewModels;

namespace CarsProject.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public CarViewModel Add(CarViewModel c)
        {
            List<Car> _carList = _carRepository.Get();
            if (_carList == null || _carList.Count == 0)
                c.Id = 1;
            else
                c.Id = _carList.Max(c => c.Id) + 1;

            Car added = _carRepository.Add(c.ToEntity());
            return new CarViewModel(added);
        }

        public CarViewModel Edit(CarViewModel c)
        {
            if (!CarExists(c))
                throw new Exception("Car to edit not found!");

            Car added = _carRepository.Edit(c.ToEntity());
            return new CarViewModel(added);
        }

        public bool Remove(CarViewModel c)
        {
            if (!CarExists(c))
                throw new Exception("Car to remove not found!");

            return _carRepository.Remove(c.ToEntity());
        }

        public CarViewModel Get(int id)
        {
            Car searched = _carRepository.Get(id);
            return new CarViewModel(searched);
        }

        public List<CarViewModel> Get()
        {
            List<Car> _cars = _carRepository.Get();
            return _cars.Select(c => new CarViewModel(c)).ToList();
        }


        private bool CarExists(CarViewModel c)
        {
            Car searched = _carRepository.Get(c.Id);
            if (searched == null || searched.Id < 1)
                return false;

            return true;
        }


    }
}
