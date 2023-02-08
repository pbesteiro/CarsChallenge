using CarsProject.Models;
using CarsProject.ViewModels;

namespace CarsProject.Repositories
{
    public class CarRepository : ICarRepository
    {
        private static List<Car> _cars = new(){
            new Car { Id = 1, Make = "Audi", Model = "R8", Year = 2018, Doors = 2, Color = "Red", Price = 79995 },
            new Car { Id = 2, Make = "Tesla", Model = "3", Year = 2018, Doors = 4, Color = "Black", Price = 54995 },
            new Car { Id = 3, Make = "Porsche", Model = " 911 991", Year = 2020, Doors = 2, Color = "White", Price = 155000 },
            new Car { Id = 4, Make = "Mercedes-Benz", Model = "GLE 63S", Year = 2021, Doors = 5, Color = "Blue", Price = 83995 },
            new Car { Id = 5, Make = "BMW", Model = "X6 M", Year = 2020, Doors = 5, Color = "Silver", Price = 62995 },
            };

        public Car Add(Car c)
        {
            _cars.Add(c);
            return c;
        }

        public Car Edit(Car c)
        {
            int index = _cars.FindIndex(cd => cd.Id == c.Id);
            _cars[index] = c;
            return c;
        }

        public bool Remove(Car c)
        {
            int index = _cars.FindIndex(cd => cd.Id == c.Id);
            _cars.RemoveAt(index);
            return true;
        }


        public Car Get(int id)
        {

            return _cars.FirstOrDefault(c => c.Id == id);
        }


        public List<Car> Get()
        {
            return _cars.OrderBy(c => c.Make).ToList();
        }



    }
}
