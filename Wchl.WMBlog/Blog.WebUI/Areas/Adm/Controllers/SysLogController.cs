using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Blog.Common;
using Blog.Common.Cache;
using Blog.Domain.Models;
using Blog.IService.ISysServices;
using Blog.ViewModels;
using Blog.WebCore.MvcExtension;
using Blog.WebUI.Core;
using Blog.WebUI.Infrastructure;
using Microsoft.ApplicationInsights.Extensibility.Implementation;

namespace Blog.WebUI.Areas.Adm.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class SysLogController : BaseController
    {

        #region 注入

        private readonly ILogService _logService;
        private readonly LogHandler handler;

        public SysLogController(ILogService log,LogHandler hand)
        {
            this._logService = log;
            this.handler = hand;
        }
        #endregion

        /// <summary>
        /// 日志
        /// </summary>
        /// <returns></returns>
        //[ClaimsAccess(Issuer = "System", ClaimType = ClaimTypes.Role, Value = "SuperAdmin")]
        public ActionResult Index()
        {
            List<SysLogs> list = _logService.GetAll();
            return View();
        }
        
        public JsonResult GetList(string page="1",string limit="10")
        {
            GridPager pages=new GridPager();
            pages.page = int.Parse(page);
            pages.rows = int.Parse(limit);
            pages.order = "ASC";
            pages.totalRows = 0;
            List<SysLogs> list = _logService.GetList(ref pages, "");
            var json = new
            {
                code= 0,
                msg= "",
                count = pages.totalRows,
                data = (from r in list
                    select new SysLogViewModel()
                    {
                        Id = r.Id.ToString(),
                        Operator = r.Operator,
                        Message = r.Message,
                        Result = r.Result,
                        Type = r.Type,
                        Module = r.Module,
                        CreateTime = r.CreateTime

                    }).ToArray()
            };

            return Json(json);
        }

    }
}