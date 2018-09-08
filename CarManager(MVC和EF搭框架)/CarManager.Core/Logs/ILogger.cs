using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Core.Logs
{
    /// <summary>
    /// 日志
    /// </summary>
    public interface ILogger
    {
        void Debug(string message);
        void Debug(string message,Exception exception);


        void Error(string message);
        void Error(string message, Exception exception);


        void Fatel(string message);
        void Fatel(string message, Exception exception);

        void Info(string message);
        void Info(string message, Exception exception);

        void Warn(string message);
        void Warn(string message, Exception exception);

    }
}
