using Blog.Common;
using Blog.IService.ISysServices;
using Blog.Service.SysServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.IService;
using Blog.Service;
using Unity;

namespace ServiceRegister
{
    public class ServiceRegister: IDependencyRegister
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType(typeof(IBaseService<>),typeof(BaseServices<>));
            container.RegisterType<ISysUserInfoService, SysUserInfoService>();
        }
    }
}
