using CarsProject.Services;
using CarsProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarsProject.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _service;

        public CarController(ICarService service)
        {
            _service = service;
        }


        // GET: CarController
        public ActionResult Index()
        {
            List<CarViewModel> _cars = _service.Get();
            return View(_cars);
        }

        // GET: CarController/Details/5
        public ActionResult Details(int id)
        {
            CarViewModel _car = _service.Get(id);
            return View(_car);
        }

        // GET: CarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarViewModel car)
        {
            try
            {
                _service.Add(car);
                return View("Index", _service.Get());
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Edit/5
        public ActionResult Edit(int id)
        {
            CarViewModel _car = _service.Get(id);
            return View(_car);
        }

        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarViewModel car)
        {
            try
            {
                _service.Edit(car);
                return View("Index", _service.Get());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Edit", ex.Message);
                return View();
            }
        }

        // GET: CarController/Delete/5
        public ActionResult Delete(int id)
        {
            CarViewModel _car = _service.Get(id);
            return View(_car);
        }

        // POST: CarController/Delete/5
        [HttpPost]
        public ActionResult Delete(CarViewModel car)
        {
            try
            {
                _service.Remove(car);
                return View("Index", _service.Get());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Edit", ex.Message);
                return View();
            }
        }


        [HttpPost]
        public JsonResult GuessPrice(double priceGuessed, double currentPrice)
        {
            double priceDiff = (currentPrice - priceGuessed);
            if (Math.Abs(priceDiff) <= 5000)
                return Json(true);
            else
                return Json(false);
        }
    }
}
