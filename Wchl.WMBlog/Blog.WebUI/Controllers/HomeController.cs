using Blog.IService.ISysServices;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Domain.Models;

using Blog.ViewModels;
using Blog.WebCore.MvcExtension;
using AutoMapper;
using Blog.Common.Json;
using Blog.WebUI.Core;
using Blog.WebUI.Infrastructure;
using Blog.WebUI.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Blog.WebUI.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {

        private readonly ISysUserInfoService _userInfoService;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfig;

        public HomeController(ISysUserInfoService userInfoService, IMapper mapper, MapperConfiguration mapperConfig)
        {
            this._userInfoService = userInfoService;
            this._mapper = mapper;
            this._mapperConfig = mapperConfig;
        }

        [AllowAnonymous]
        public ActionResult Index(string page="1")
        {
            var user = CurrentUser;
            var userlist = UserManager.Users.ToList();


            ViewBag.returnUrl = "/Home/Index";
            ViewBag.totalcount = userlist.Count;//博文总数

            return View();
        }


        [Authorize]
        public ActionResult UserProps()
        {
            //获取当前登录用户
            AppUser user = CurrentUser;
            return View(CurrentUser);
        }
        

        [AllowAnonymous]
        public ActionResult MainPage()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Create(SysUserInfoViewModel user)
        {
            var flag = true;
            if (ModelState.IsValid)
            {
                SysUserInfo model = _mapper.Map<SysUserInfoViewModel, SysUserInfo>(user);
                model.UId = 1;
                if(_userInfoService.Add(ref errors, model))
                {
                    return Json(JsonHandler.CreateMessage(1, "创建成功"), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    string ErrorCol = errors.Error;
                    return Json(JsonHandler.CreateMessage(1, "创建失败"+ErrorCol), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(JsonHandler.CreateMessage(0, "创建失败,数据未通过验证"), JsonRequestBehavior.AllowGet);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Delete(int id)
        {
            _userInfoService.Delete(ref errors,a=>a.UId==id);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            List<SysUserInfo> editmodel = _userInfoService.QueryWhere(a => a.UId == id);
            if (editmodel.Count>0)
            {
                SysUserInfo model = editmodel.FirstOrDefault();
                SysUserInfoViewModel editViewModel = _mapper.Map<SysUserInfo, SysUserInfoViewModel>(model);
                return View(editViewModel);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Edit(SysUserInfoViewModel model)
        {
            if (ModelState.IsValid)
            {
                SysUserInfo user = _mapper.Map<SysUserInfoViewModel, SysUserInfo>(model);
                _userInfoService.Edit(ref errors,user);
                return RedirectToAction(nameof(Index));

            }

            return View(model);
        }
    }
}