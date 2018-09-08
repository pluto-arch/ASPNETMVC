using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Common;
using Blog.Domain.Models;
using Blog.IService.ISysServices;
using Blog.ViewModels;
using Blog.WebCore.MvcExtension;
using Blog.WebUI.Core;
using Blog.WebUI.Infrastructure;

namespace Blog.WebUI.Areas.Adm.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class SysExceptionController : BaseController
    {
        #region 注入

        private readonly ISysExceptionService _expService;

        public SysExceptionController(ISysExceptionService exp)
        {
            this._expService = exp;
        }
        #endregion
        // GET: Adm/SysException
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetList(string page="1",string limit="10")
        {
            GridPager pages = new GridPager();
            pages.page = int.Parse(page);
            pages.rows = int.Parse(limit);
            pages.order = "ASC";
            pages.totalRows = 0;
            List<SysExceptions> list = _expService.GetList(ref pages, "");
            var json = new
            {
                code = 0,
                msg = "",
                count = pages.totalRows,
                data = (from r in list
                    select new SysExceptionViewModel()
                    {
                        Id = r.Id,
                        HelpLink = r.HelpLink,
                        Message = r.Message,
                        Source = r.Source,
                        StackTrace = r.StackTrace,
                        TargetSite = r.TargetSite,
                        Data = r.Data,
                        CreateTime = r.CreateTime
                    }).ToArray()

            };
            return Json(json);
        }

        [AllowAnonymous]
        public ActionResult Error()
        {
            return View();
        }

    }
}