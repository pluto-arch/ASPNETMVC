using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace Blog.WebUI.Infrastructure
{
    public static class IdentityHelpers
    {
        /// <summary>
        /// Entity Framework的IdentityRole类中定义了一个Users属性，它能够返回表示角色成员的IdentityUserRole用户对象集合。每一个IdentityUserRole对象都有一个UserId属性，它返回一个用户的唯一ID，不过，我希望得到的是每个ID所对应的用户名。我在Infrastructure文件夹中添加了一个类文件，名称为IdentityHelpers.cs
        ///
        /// 通过GetOwinContext.GetUserManager方法获取AppUserManager的一个实例（其中GetOwinContext是HttpContext类的扩展方法），并使用FindByIdAsync方法定位与ID相关联的AppUser实例，然后返回UserName属性的值
        /// </summary>
        /// <param name="html"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static MvcHtmlString GetUserName(this HtmlHelper html, string id)
        {
            AppUserManager mgr= HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();
            return new MvcHtmlString(mgr.FindByIdAsync(id).Result.UserName);
        }


        public static MvcHtmlString ClaimType(this HtmlHelper html, string claimType)
        {
            FieldInfo[] fields = typeof(ClaimTypes).GetFields();
            foreach (FieldInfo field in fields)
            {
                if (field.GetValue(null).ToString() == claimType)
                {
                    return new MvcHtmlString(field.Name);
                }
            }
            return new MvcHtmlString(string.Format("{0}",
                claimType.Split('/', '.').Last()));
        }

    }
}