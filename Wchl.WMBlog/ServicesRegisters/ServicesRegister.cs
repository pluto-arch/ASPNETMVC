using Blog.Common;
using Blog.IService.ISysServices;
using Blog.Service.SysServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Common.Cache;
using Blog.IService;
using Blog.Service;
using Unity;

namespace ServicesRegisters
{
    /// <summary>
    /// 服务层注入
    /// </summary>
    public class ServicesRegister : IDependencyRegister
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ISysUserInfoService, SysUserInfoService>();
            container.RegisterType<ILogService, LogServices>();
            container.RegisterType<ISysExceptionService, SysExceptionService>();
            container.RegisterType(typeof(IBaseService<>), typeof(BaseServices<>));
        }
    }
}
