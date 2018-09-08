using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using Blog.Common;
using Blog.Domain.Models;
using Blog.IService.ISysServices;

namespace Blog.WebUI.Infrastructure
{
    public class LogHandler
    {
        private readonly ILogService _service;
        public ValidationErrors errors = new ValidationErrors();
        public LogHandler(ILogService service)
        {
            this._service = service;
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="oper">操作人</param>
        /// <param name="mes">操作细节</param>
        /// <param name="result">操作结果</param>
        /// <param name="type">操作类型</param>
        /// <param name="module">操作模块</param>
        public void WriteServiceLog(string oper, string mes, string result, string type, string module)
        {
            SysLogs entity = new SysLogs();
            entity.Operator = oper;
            entity.Message = mes;
            entity.Result = result;
            entity.Type = type;
            entity.Module = module;
            entity.CreateTime = ResultHelper.NowTime;
             _service.AddLog(ref errors,entity);
        }
    }
}