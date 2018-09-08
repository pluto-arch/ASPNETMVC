using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using 注册登录.Infrastructure;
using 注册登录.Models;

namespace 注册登录.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IAuthenticationManager AuthManager{get{return HttpContext.GetOwinContext().Authentication;}}
        private AppUserManager UserManager{get{return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();}
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]  /*ValidateAntiForgeryToken注解属性，该属性与视图中的Html.AntiForgeryToken辅助器方法联合工作，防止Cross-Site Request Forgery（CSRF，跨网站请求伪造）的攻击*/
        public async Task<ActionResult> Login(LoginModel details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await UserManager.FindAsync(details.Name,details.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid name or password.");
                }
                else
                {
                    /*
                     * 如果FindAsync方法确实返回了AppUser对象，那么则需要创建Cookie，浏览器会在后继的请求中发送这个Cookie，表明他们是已认证的
                     */

                    //创建表示用户的声明标识
                    ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user,DefaultAuthenticationTypes.ApplicationCookie);

                    ident.AddClaims(LocationClaimsProvider.GetClaims(ident));//在认证过程期间，声明（Claims）是与用户标识关联在一起的
                    ident.AddClaims(ClaimsRoles.CreateRolesFromClaims(ident));//根据声明生成角色

                    AuthManager.SignOut();//签出用户，这通常意味着使标识已认证用户的Cookie失效
                    //SignIn:签入用户，这通常意味着要创建用来标识已认证请求的Cookie
                    //SignIn方法的参数是一个AuthenticationProperties对象，用以配置认证过程的ClaimsIdentity对象。我将AuthenticationProperties对象定义的IsPersistent属性设置为true，以使认证Cookie在浏览器中是持久化的，意即用户在开始新会话时，不必再次进行认证
                    AuthManager.SignIn(new AuthenticationProperties
                    {
                        //获取或设置是否跨多个请求持久保存身份验证会话。
                        IsPersistent = false
                    }, ident);
                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(details);
        }

        [Authorize]
        public ActionResult Logout()
        {
            AuthManager.SignOut();
            return RedirectToAction("Index", "Home");
        }



        [HttpPost]
        [AllowAnonymous]
        public ActionResult GoogleLogin(string returnUrl)
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleLoginCallback",
                    new { returnUrl = returnUrl })
            };
            HttpContext.GetOwinContext().Authentication.Challenge(properties, "Google");
            return new HttpUnauthorizedResult();
        }

        [AllowAnonymous]
        public async Task<ActionResult> GoogleLoginCallback(string returnUrl)
        {
            ExternalLoginInfo loginInfo = await AuthManager.GetExternalLoginInfoAsync();
            AppUser user = await UserManager.FindAsync(loginInfo.Login);
            if (user == null)
            {
                user = new AppUser
                {
                    Email = loginInfo.Email,
                    UserName = loginInfo.DefaultUserName,
                    City = Cities.LONDON,
                };
                IdentityResult result = await UserManager.CreateAsync(user);
                if (!result.Succeeded)
                {
                    return View("Error", result.Errors);
                }
                else
                {
                    result = await UserManager.AddLoginAsync(user.Id, loginInfo.Login);
                    if (!result.Succeeded)
                    {
                        return View("Error", result.Errors);
                    }
                }
            }

            ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user,
                DefaultAuthenticationTypes.ApplicationCookie);
            ident.AddClaims(loginInfo.ExternalIdentity.Claims);
            AuthManager.SignIn(new AuthenticationProperties
            {
                IsPersistent = false
            }, ident);
            return Redirect(returnUrl ?? "/");
        }


    }
}