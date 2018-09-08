using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Common.Log;

namespace Blog.WebCore
{
    public class NLogHelper:ILogHelper
    {
        public  void WriteLog(LogLevel levle, string origin, string message, string exception, string loclevle, string stackTrace)
        {
            NLogLogger nlog = new NLogLogger();
            LogEventInfo ei = new LogEventInfo(levle, "", "");
            //这些字段和数据库对应
            ei.Properties["Origin"] = origin;
            ei.Properties["LogLevel"] = loclevle;
            ei.Properties["Message"] = message;
            ei.Properties["Exception"] = exception;
            ei.Properties["StackTrace"] = stackTrace;
            //记录日志
            nlog.Fatel(ei);
        }
    }
}
