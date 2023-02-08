using CarsProject.Models;
using CarsProject.Repositories;
using CarsProject.Services;
using CarsProject.ViewModels;
using Moq;
using System.Runtime.InteropServices;

namespace CarTestProject
{
    public class Tests
    {
        private Mock<ICarRepository> _carRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _carRepositoryMock = new Mock<ICarRepository>();
        }

        [Test]
        public void WhenTryToEditAnInexistentCar_ShouldThrowAnException()
        {
            CarViewModel car = new() { Id = 1, Color = "grey", Door = 2, Make = "MakeTest", Model = "TestModel", Price = 10000, Year = 2018 };
            _carRepositoryMock.Setup(r => r.Get(It.IsAny<int>())).Returns<Car>(null);
            CarService service = new (_carRepositoryMock.Object);

            Assert.Throws<Exception>(() => service.Edit(car));
        }


        [Test]
        public void WhenTryToEditAnExistentCar_ShouldEdit()
        {
            CarViewModel car = new () { Id = 1, Color = "grey", Door = 2, Make = "MakeTest", Model = "TestModel", Price = 10000, Year = 2018 };
            Car responseCar = car.ToEntity();
            _carRepositoryMock.Setup(r => r.Get(It.IsAny<int>())).Returns(responseCar);
            _carRepositoryMock.Setup(r => r.Edit(It.IsAny<Car>())).Returns(responseCar);
            CarService service = new (_carRepositoryMock.Object);

            CarViewModel carEdited = service.Edit(car);

            Assert.That(carEdited.Id,Is.EqualTo(1));
            Assert.That(carEdited.Color, Is.EqualTo("grey"));
            Assert.That(carEdited.Door,  Is.EqualTo(2));
            Assert.That(carEdited.Make,  Is.EqualTo("MakeTest"));
            Assert.That(carEdited.Price,  Is.EqualTo(10000));
        }

    }
}