using CarManager.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarManager.Data.Domain;
using CarManager.Web.Models.Cars;
using CarManager.WebCore.MvcExtension;

namespace CarManager.Web.Controllers
{
    public class CarController : BaseController
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            this._carService = carService;
        }

        // GET: Car
        public ActionResult Index()
        {
            var models = _carService.GetAllCars().Select(a =>
                new CarViewModel() {Name = a.CarName, Price = a.Price, CreateTime = a.CreateTime});
            return View(models);
        }

        public JsonResult GetCarJson()
        {
            //使用自带的json转换  时间会转换有问题
            return Json(_carService.GetAllCars(),JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CarViewModel entity)
        {
            if (ModelState.IsValid)
            {
                Car model=new Car();
                model.CreateTime = entity.CreateTime;
                model.CarName = entity.Name;
                model.Price = entity.Price;
                _carService.CreateCar(model);
                return RedirectToAction(nameof(Index));
            }

            return View(entity);
        }
    }
}