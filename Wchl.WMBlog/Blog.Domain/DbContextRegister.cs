using Blog.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace Blog.Domain
{
    /// <summary>
    /// EF上下文注入
    /// </summary>
    public class DbContextRegister : IDependencyRegister
    {
        public void RegisterTypes(IUnityContainer container)
        {
            //容器控制生命周期管理，这个生命周期管理器是RegisterInstance默认使用的生命周期管理器，也就是单件实例，UnityContainer会维护一个对象实例的强引用，每次调用的时候都会返回同一对象
            container.RegisterType<IDbContext, BlogDbContext>(new ContainerControlledLifetimeManager());
        }
    }
}
