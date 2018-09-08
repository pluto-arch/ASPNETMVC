using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Common;
using Blog.Common.Log;
using Blog.Domain;
using Blog.Domain.Models;
using Blog.IService.ISysServices;
using Blog.Repository.SysRepository;

namespace Blog.Service.Core
{
    public static class ExceptionHander
    {
        /// <summary>
        /// 加入异常日志
        /// </summary>
        /// <param name="ex">异常</param>
        public static void WriteException(Exception ex)
        { 
            try
            {
                SysExceptionRepository exce = new SysExceptionRepository(new BlogDbContext());
                SysExceptions model = new SysExceptions()
                {
                    
                    HelpLink = ex.HelpLink,
                    Message = ex.Message,
                    Source = ex.Source,
                    StackTrace = ex.StackTrace,
                    TargetSite = ex.TargetSite.ToString(),
                    Data = ex.Data.ToString(),
                    CreateTime = ResultHelper.NowTime
                };
                exce.AddExceptoon(model);

            }
            catch (Exception ep)
            {
                try
                {
                    NLogLogger log=new NLogLogger();
                    log.Fatel(ep.Message);
                }
                catch { return; }
            }



        }
    }
}
