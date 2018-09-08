using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using 注册登录.Infrastructure;

namespace 注册登录.Controllers
{
    public class ClaimsController : Controller
    {
        /*
         * 只要用户的声明（Claims）承认他们是DCStaff角色的成员，那么他们便能访问OtherAction动作。该角色的成员是动态生成的，因此，若是用户的雇用状态或地点信息发生变化，也会改变他们的授权等级
         */
        [Authorize(Roles = "DCStaff")]
        public string OtherAction()
        {
            return "This is the protected action";
        }

        /// <summary>
        /// 自定义特性授权访问
        /// 授权过滤器能够确保只有地点声明（Claim）的邮编为DC 20500的用户才能请求OtherAction1方法
        /// </summary>
        /// <returns></returns>
        [ClaimsAccess(Issuer = "RemoteClaims", ClaimType = ClaimTypes.PostalCode,
            Value = "DC 20500")]
        public string OtherAction1()
        {
            return "This is the protected action";
        }

        private AppUserManager UserManager { get { return HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); } }

        [Authorize]

        public ActionResult Index()
        {
            //用户类的Claims属性属于ASP.NET Identity，而HttpContext.User.Identity属性则属于ASP.NET平台(已经集成)
            //HttpContext.User.Identity属性返回IIdentity的接口实现
            //当使用ASP.NET Identity时，该实现是一个ClaimsIdentity对象
            /*
             * ClaimsIdentity类是在System.Security.Claims命名空间中定义的
             * 主要成员：
             * Claims---------返回表示用户声明（Claims）的Claim对象枚举
             * AddClaim(claim)-------------给用户添加一个声明（Claim）
             * AddClaims(claims)---------给用户添加Claim对象的枚举。
             * HasClaim(predicate)----------如果用户含有与指定谓词匹配的声明（Claim）时，返回true
             * RemoveClaim(claim)--------删除用户的声明（Claim）。
             */
            ClaimsIdentity ident = HttpContext.User.Identity as ClaimsIdentity;
            if (ident == null)
            {
                return View("Error", new string[] { "No claims available" });
            }
            else
            {
                //ClaimsIdentity.Claims属性所返回的Claim对象的枚举
                return View(ident.Claims);
            }
            /*
             *Claim类定义的属性
             * Issuer-------返回提供声明（Claim）的系统名称
             * Subject---------返回声明（Claim）所指用户的ClaimsIdentity对象
             * Type--------返回声明（Claim）所表示的信息类型
             * Value------返回声明（Claim）所表示的信息片段
             */
        }
    }
}