using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManager.Core.Infrastucture;
using CarManager.Service.IService;
using CarManager.Service.Service;
using Unity;

namespace CarManager.Service
{
    /// <summary>
    /// 服务层注入
    /// </summary>
    public class ServiceRegister : IDependencyRegister
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ICarService, CarService>();
        }
    }
}
