using CarsProject.Models;
using System.ComponentModel.DataAnnotations;

namespace CarsProject.ViewModels
{
    public class CarViewModel
    {
        public CarViewModel()
        { 

        }

        public CarViewModel(Car c)
        {
            this.Id = c.Id;
            this.Make = c.Make;
            this.Model = c.Model;
            this.Color = c.Color;
            this.Year = c.Year;
            this.Price = c.Price;
            this.Door = c.Doors;
        }

        public Car ToEntity()
        {
            Car c = new Car
            {
                Id = this.Id,
                Make = this.Make,
                Model = this.Model,
                Color = this.Color,
                Year = this.Year,
                Price = this.Price,
                Doors = this.Door,
            };

            return c;
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        public string Make { get; set; }

        [Required]
        [MinLength(1)]
        public string Model { get; set; }

        [Required]
        [Range(1900, int.MaxValue, ErrorMessage = "Please enter a year bigger than {1}")]
        public int Year { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a numbrer of doors bigger than {1}")]
        public int Door { get; set; }

        [Required]
        [MinLength(1)]
        public string Color { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a price bigger than {1}")]
        public double Price { get; set; }
    }
}
