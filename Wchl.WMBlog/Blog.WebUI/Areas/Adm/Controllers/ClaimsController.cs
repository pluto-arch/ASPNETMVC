using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Areas.Adm.Controllers
{
    /// <summary>
    /// 用户声明
    /// </summary>
    [Authorize(Roles = "Administrators")]
    public class ClaimsController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            //获取登录用户的声明  因为在登录时创建了声明
            ClaimsIdentity ident = HttpContext.User.Identity as ClaimsIdentity;
            if (ident == null)
            {
                return View("Error", new string[] { "没有登录" });
            }
            else
            {
                return View(ident.Claims);
            }
        }
    }
}