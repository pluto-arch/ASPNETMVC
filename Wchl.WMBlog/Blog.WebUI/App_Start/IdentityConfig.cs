using System;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Blog.WebUI.Infrastructure;

namespace Blog.WebUI
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {

            app.CreatePerOwinContext<AppIdentityDbContext>(AppIdentityDbContext.Create);
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            app.CreatePerOwinContext<AppRoleManager>(AppRoleManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                CookieName="zylblog.userCookie",
                CookieHttpOnly=false,//确定浏览器是否应允许客户端javascript访问cookie。默认值为true，这意味着cookie将仅传递给http请求，并且不可用于页面上的脚本。
                LoginPath = new PathString("/Account/Login"),
//                ExpireTimeSpan = TimeSpan.FromMinutes(30),//设置认证cookie的过期时间
//                SlidingExpiration = true,
            });
        }
    }
}