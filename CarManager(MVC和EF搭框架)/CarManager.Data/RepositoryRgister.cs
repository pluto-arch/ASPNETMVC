using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManager.Core.Infrastucture;
using CarManager.Data.IRepository;
using CarManager.Data.Repository;
using Unity;

namespace CarManager.Data
{
    /// <summary>
    /// 仓储层的注入
    /// </summary>
    public class RepositoryRgister : IDependencyRegister
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IDbContext, CarDbContext>();//最后括号里可指定生命周期
            container.RegisterType(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}
