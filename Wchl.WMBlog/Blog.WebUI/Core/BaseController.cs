using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Blog.Common;
using Blog.WebCore;
using Blog.WebCore.MvcExtension;
using Blog.WebUI.Infrastructure;
using Blog.WebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Blog.WebUI.Core
{

    public class BaseController:Controller
    {
        public ValidationErrors errors=new ValidationErrors();

        public AppRoleManager RoleManager { get { return HttpContext.GetOwinContext().GetUserManager<AppRoleManager>(); } }
        public IAuthenticationManager AuthManager { get { return HttpContext.GetOwinContext().Authentication; } }
        public AppUserManager UserManager { get { return HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); } }

        /// <summary>
        /// 重写，解决json时间格式问题
        /// </summary>
        /// <param name="data"></param>
        /// <param name="contentType"></param>
        /// <param name="contentEncoding"></param>
        /// <returns></returns>
        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonNetResult() { Data = data, ContentType = contentType, ContentEncoding = contentEncoding, JsonRequestBehavior = behavior };
        }


        public AppUser CurrentUser
        {
            get
            {
                string username = HttpContext.User.Identity.Name ;
                return UserManager.FindByName(HttpContext.User.Identity.Name);
            }
        }

    }
}
