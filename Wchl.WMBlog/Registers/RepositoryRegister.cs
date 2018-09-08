using Blog.Common;
using Blog.IRepository.ISysRepository;
using Blog.Repository.SysRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.IRepository;
using Blog.Repository;
using Unity;
using Unity.Lifetime;

namespace Registers
{
    /// <summary>
    /// 仓储注入
    /// </summary>
    public class RepositoryRegister : IDependencyRegister
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ISysUserInfoRepository, SysUserInfoRepository>();
            container.RegisterType<ILogRepository, LogRepository>(new ContainerControlledLifetimeManager());//全局共用
            container.RegisterType<ISysExceptionRepository, SysExceptionRepository>(new ContainerControlledLifetimeManager());//全局共用
            container.RegisterType(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}
