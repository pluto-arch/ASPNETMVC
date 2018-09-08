using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.WebCore
{
    public interface ILogHelper
    {
       void WriteLog(LogLevel levle, string origin, string message, string exception,string loclevle,string stackTrace);
    }
}
