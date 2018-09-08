using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Common.Cache;
using Blog.Common.Log;
using Unity;
using Unity.Lifetime;

namespace Blog.Common
{
    /// <summary>
    /// 基础工具的注入
    /// </summary>
    public class InfrastuctureRegister : IDependencyRegister
    {
        public void RegisterTypes(IUnityContainer container)
        {
            //ContainerControlledLifetimeManager  单例 内存中只有一份，所有人拿到的都是同一个
            container.RegisterType<ICacheManager,MemoryCacheManager>(new ContainerControlledLifetimeManager());//内存缓存注入
            container.RegisterType<ILogger, NullLogger>();//空日志注入
        }
    }
}
