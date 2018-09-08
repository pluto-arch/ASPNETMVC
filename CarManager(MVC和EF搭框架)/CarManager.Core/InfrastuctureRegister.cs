using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManager.Core.Cache;
using CarManager.Core.Infrastucture;
using CarManager.Core.Logs;
using Unity;

namespace CarManager.Core
{
    /// <summary>
    /// 基础设施的注入
    /// </summary>
    public class InfrastuctureRegister : IDependencyRegister
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ILogger, NullLogger>();//注入日志
            container.RegisterType<ICacheManager, MemoryCacheManager>();//注入缓存
        }
    }
}
