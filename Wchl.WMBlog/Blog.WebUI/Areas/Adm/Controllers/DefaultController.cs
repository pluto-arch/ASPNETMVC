using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Blog.Common.Json;
using Blog.WebUI.Core;
using Blog.WebUI.Infrastructure;
using Blog.WebUI.Models;
using Blog.WebUI.Models.UserModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Blog.WebUI.Areas.Adm.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class DefaultController : BaseController
    {
     

        private readonly LogHandler _log;
        public DefaultController(LogHandler log)
        {
            this._log = log;
        }


        //起始页
        public ActionResult Main()
        {
            AppUser user = CurrentUser;
            if (user!=null)
            {
                return View(user);
            }
            return RedirectToAction("Login", "Account", new { area = "" ,returnUrl="/Adm/Default/Main"});
        }
        //首页
        public ActionResult Index()
        {

            return View();
        }
        /// <summary>
        /// 用户管理页
        /// </summary>
        /// <returns></returns>
        public ActionResult BlogUserList()
        {
            return View(UserManager.Users);
        }

        #region 新增用户
        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser loginuser = CurrentUser;
                AppUser user = new AppUser { UserName = model.Name, Email = model.Email };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    
                    _log.WriteServiceLog(loginuser.UserName, "" + CurrentUser.Id + "：添加新用户", "操作成功","Create","/Adm/Default/Create");
                    return RedirectToAction(nameof(BlogUserList));
                }
                else
                {
                    _log.WriteServiceLog(loginuser.UserName, "" + CurrentUser.Id + "]添加新用户", "操作失败", "Create", "/Adm/Default/Create");
                    AddErrorsFromResult(result);
                }
            }
            return View(model);
        }

        #endregion


        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public JsonResult Logout()
        {
            AuthManager.SignOut();
            _log.WriteServiceLog(CurrentUser.UserName, "ID为：[" + CurrentUser.Id + "]的用户登出", "登出成功", "Logout", "/Adm/Default/Logout");
            return Json(JsonHandler.CreateMessage(1, "登出成功", "/Home/Index",null), JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 个人资料
        /// </summary>
        /// <returns></returns>
        public ActionResult Profile(string id)
        {
            ViewBag.profiletitle = CurrentUser.UserName+"：个人信息";
            ViewBag.uid = id;

           


            AppUser user = UserManager.FindById(id);
            if (user != null)
            {
                ViewBag.firstname = user.FirstName;
                ViewBag.lastname = user.LastName;
                ViewBag.gender = user.Gender==true ? "1" : "0";
                ViewBag.email = user.Email;
                ViewBag.phone = user.PhoneNumber;
                ViewBag.birthday = string.Format("{0:yyyy-MM-dd}", user.BirthDateTime) ;
                ViewBag.age = user.Age;
                ViewBag.nickname = user.NickName;
                ViewBag.address = user.Country + "/" + user.ProvinceOrState + "/" + user.City;
                ViewBag.weburl = user.WebUrl;
                ViewBag.tab = user.Tab;
            }
            else
            {
                ViewBag.firstname = "";
                ViewBag.lastname = "";
                ViewBag.gender = "";
                ViewBag.email = "";
                ViewBag.phone = "";
                ViewBag.birthday = "";
                ViewBag.age = "";
                ViewBag.nickname = "";
                ViewBag.address = "";
                ViewBag.weburl = "";
                ViewBag.tab = "";
            }
            return View();
        }
        
        public JsonResult GetProcesssData()
        {
            AppUser user = CurrentUser;
          
            return Json(JsonHandler.CreateMessage(1, "信息完整度", "80%",null), JsonRequestBehavior.AllowGet);
        }








        /*
         *  <li class="tpl-dropdown-list-bdbc">
           <table class="am-table">
            <tbody>
            <tr>
             <td class="tpl-dropdown-list-fl">
             <a href="#">
             <span class="am-icon-btn am-icon-check tpl-dropdown-ico-btn-size tpl-badge-warning">
             </span><span style="color: chocolate">移动端，导航条下边距处理</span>
             </a></td><td class="tpl-dropdown-list-fr ">
               <span style="color: blueviolet">15分钟前</span>
               </td></tr></tbody></table></li>
         */

        /// <summary>
        /// 测试ajax
        /// </summary>
        /// <returns></returns>
        public string GetDate()
        {
            StringBuilder sb=new StringBuilder();
            sb.Append("<li class=\"tpl-dropdown-list-bdbc\">");
            sb.Append( "<table class=\"am-table\">");
            sb.Append("<tbody>");
            sb.Append("<tr>");
            sb.Append("<td class=\"tpl-dropdown-list-fl\">");
            sb.Append("  <a href=\"#\">");
            sb.Append("  <span class=\"am-icon-btn am-icon-check tpl-dropdown-ico-btn-size tpl-badge-warning\">");
            sb.Append(" </span><span style=\"color: chocolate\">hahahahah</span>");
            sb.Append("   </a></td><td class=\"tpl-dropdown-list-fr \">");
            sb.Append("<span style=\"color: blueviolet\">15分钟前</span>");
            sb.Append("</td></tr></tbody></table></li>");
            return  sb.ToString();
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