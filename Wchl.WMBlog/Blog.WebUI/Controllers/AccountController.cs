using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Blog.Common.Json;
using Blog.WebCore;
using Blog.WebCore.MvcExtension;
using Blog.WebUI.Core;
using Blog.WebUI.Infrastructure;
using Blog.WebUI.Models;
using Blog.WebUI.Models.UserModels;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Unity;

namespace Blog.WebUI.Controllers
{
    public class AccountController : BaseController
    {

        private LogHandler _log;

        public AccountController(LogHandler log)
        {
            this._log = log;
        }

     
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {

            //if (HttpContext.User.Identity.IsAuthenticated)
            //{
            //    return View("NoAuthenticated");//没有验证过的用户跳转
            //}
            if (string.IsNullOrEmpty(returnUrl))
            {
                returnUrl = "/";
            }
            ViewBag.returnUrl = returnUrl;
            ViewBag.loginTitle = "Welcome to my Blog Platform";
            ViewBag.Title = "Login";
            return View();
        }


        //控制器类上运用了Authorize注解属性，然后又在个别动作方法上运用了AllowAnonymous注解属性。这会将这些动作方法默认限制到已认证用户，但又能允许未认证用户登录到应用程序
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]//ValidateAntiForgeryToken注解属性，该属性与视图中的Html.AntiForgeryToken辅助器方法联合工作，防止Cross-Site Request Forgery（CSRF，跨网站请求伪造）的攻击
        public async Task<JsonResult> Login(LoginModel details, string returnUrl="/Home/Index",string loginadmin="off")
        {

            if (ModelState.IsValid)
            {
                AppUser user = await UserManager.FindAsync(details.Name,
                    details.Password);
                if (user == null)
                {
                    return Json(JsonHandler.CreateMessage(-1, "用户名或密码不存在",returnUrl),JsonRequestBehavior.AllowGet);
                }
                else
                {
                    ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user,
                        DefaultAuthenticationTypes.ApplicationCookie);//创建一个标识该用户的ClaimsIdentity对象。ClaimsIdentity类是IIdentity接口的ASP.NET Identity实现

                    ident.AddClaims(LocationClaimsProvider.GetClaims(ident,user));//添加自定义声明
                    //ident.AddClaims(ClaimsRoles.CreateRolesFromClaims(ident,user));//动态添加新角色声明而不用更新数据库

                    AuthManager.SignOut();//签出用户，这通常意味着使标识已认证用户的Cookie失效
                    AuthManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = false//获取或设置是否跨多个请求持久保存身份验证会话。
                    }, ident);//签入用户，这通常意味着要创建用来标识已认证请求的Cookie

                    _log.WriteServiceLog(user.UserName, "ID为：[" + user.Id + "],登录系统", "登录成功", "Login", "/Adm/Account/Login");

                    IList<string> uroles=UserManager.GetRoles(user.Id);
                    if (loginadmin.Trim()=="on")
                    {
                        if (uroles.Contains("Administrators"))
                        {
                            returnUrl = "/Adm/Default/";
                        }
                        else
                        {
                            returnUrl = "/Home/Index";
                            return Json(JsonHandler.CreateMessage(2, "对不起，您还不是管理员身份，即将被重定向到首页", returnUrl), JsonRequestBehavior.AllowGet);
                        } 
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(returnUrl) || returnUrl == "/")
                        {
                            returnUrl = "/Home/index";
                        }
                    }

                    return Json(JsonHandler.CreateMessage(1, "登录成功，即将跳转",returnUrl), JsonRequestBehavior.AllowGet);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return Json(JsonHandler.CreateMessage(0, "登陆失败,未通过验证", returnUrl), JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult Logout()
        {
            AuthManager.SignOut();
            _log.WriteServiceLog(CurrentUser.UserName, "ID为：[" + CurrentUser.Id + "]的用户登出", "登出成功", "Logout", "/Adm/Account/Logout");
            return RedirectToAction("Index", "Home");
        }




        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            ViewBag.registerTitle = "Welcome register";
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(CreateModel model,string returnUrl = "/")
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser { UserName = model.Name, Email = model.Email };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);//新增成功
                if (result.Succeeded)
                {
                    _log.WriteServiceLog(user.UserName, "新注册用户，ID为：[" + user.Id + "]", "注册成功", "Register", "/Adm/Account/Register");
                    if (string.IsNullOrEmpty(returnUrl))
                    {
                        returnUrl = "/";
                    }
                    return Redirect(returnUrl);
                }
                else
                {
                    _log.WriteServiceLog(model.Name, "新注册用户", "注册失败", "Register", "/Adm/Account/Register");
                    AddErrorsFromResult(result);
                }
            }
            return View(model);
        }


        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}