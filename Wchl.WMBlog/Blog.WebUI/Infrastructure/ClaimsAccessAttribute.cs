using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Infrastructure
{
    /// <summary>
    /// 要根据声明（Claims）数据来生成了角色，然后强制我的授权策略基于角色成员。一个更直接且灵活的办法是直接强制授权，其做法是创建一个自定义的授权过滤器注解属性
    /// </summary>
    public class ClaimsAccessAttribute : AuthorizeAttribute
    {

        /*
         *这个注解属性派生于AuthorizeAttribute类，通过重写AuthorizeCore方法，很容易在MVC框架应用程序中创建自定义的授权策略。在这个实现中，若用户是已认证的、其IIdentity实现是一个ClaimsIdentity实例，而且该用户有一个带有issuer、type以及value的声明（Claim），它们与这个类的属性是匹配的，则该用户便是允许访问的
         *
         * [ClaimsAccess(Issuer="RemoteClaims", ClaimType=ClaimTypes.PostalCode,Value="DC 20500")]//这个授权过滤器能够确保只有地点声明（Claim）的邮编为DC 20500的用户才能请求Action方法。
         *
         */


        public string Issuer { get; set; }
        public string ClaimType { get; set; }
        public string Value { get; set; }

        protected override bool AuthorizeCore(HttpContextBase context)
        {
            return context.User.Identity.IsAuthenticated
                   && context.User.Identity is ClaimsIdentity
                   && ((ClaimsIdentity)context.User.Identity).HasClaim(x =>
                       x.Issuer == Issuer && x.Type == ClaimType && x.Value == Value
                   );
        }
    }
}