using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManager.Data.Domain;

namespace CarManager.Service.IService
{
    public interface ICarService
    {
        Car CreateCar(Car car);
        int UpdateCar(Car car);
        bool DeleteCar(Car car);
        List<Car> GetAllCars();

    }
}
