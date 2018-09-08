using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.WebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Blog.WebUI.Infrastructure
{
    /// <summary>
    /// 角色管理类
    /// </summary>
    public class AppRoleManager : RoleManager<AppRole>, IDisposable
    {

        public AppRoleManager(RoleStore<AppRole> store) : base(store) { }

        public static AppRoleManager Create(IdentityFactoryOptions<AppRoleManager> options,IOwinContext context)
        {
            //Create方法，它让OWIN启动类能够为每一个访问Identity数据的请求创建实例，这意味着在整个应用程序中，我不必散布如何存储角色数据的细节，却能获取AppRoleManager类的实例，并对其进行操作
            return new AppRoleManager(new
                RoleStore<AppRole>(context.Get<AppIdentityDbContext>()));
        }
    }
}