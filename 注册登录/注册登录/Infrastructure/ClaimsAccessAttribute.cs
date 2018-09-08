using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace 注册登录.Infrastructure
{
    public class ClaimsAccessAttribute : AuthorizeAttribute
    {
        public string Issuer { get; set; }
        public string ClaimType { get; set; }
        public string Value { get; set; }

        /// <summary>
        /// 在这个实现中，若用户是已认证的、其IIdentity实现是一个ClaimsIdentity实例，而且该用户有一个带有issuer、type以及value的声明（Claim），它们与这个类的属性是匹配的，则该用户便是允许访问的。
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
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