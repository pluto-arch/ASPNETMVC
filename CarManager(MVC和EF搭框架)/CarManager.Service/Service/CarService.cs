using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManager.Core.Cache;
using CarManager.Data.Domain;
using CarManager.Data.IRepository;
using CarManager.Service.IService;

namespace CarManager.Service.Service
{
    public class CarService : ICarService
    {
        private const string cacheKey = nameof(CarService)+nameof(Car);//缓存的键值


        private readonly IBaseRepository<Car> _carRepository;
        private readonly ICacheManager _cache;

        public CarService(IBaseRepository<Car> carRepository, ICacheManager cache)
        {
            this._carRepository = carRepository;
            this._cache = cache;
        }


        public Car CreateCar(Car car)
        {
           return this._carRepository.Insert(car);
        }

        public bool DeleteCar(Car car)
        {
            return _carRepository.Delete(t => t.Id == car.Id);
        }

        public List<Car> GetAllCars()
        {
            if (_cache.IsExist(cacheKey))//如果缓存中有，直接存缓存中取
            {
                return _cache.Get<List<Car>>(cacheKey);
            }
            else
            {
                var carlist = _carRepository.Get();
                _cache.Set(cacheKey, carlist, new TimeSpan(0, 0, 8, 0));//缓存8分钟
                return carlist;
            }
           
        }

        public int UpdateCar(Car car)
        {
            return _carRepository.Update(car);
        }
    }
}
