using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Core.Logs
{
    /// <summary>
    /// 不记录日志
    /// </summary>
    public class NullLogger : ILogger
    {
        public void Debug(string message)
        {
        }

        public void Debug(string message, Exception exception)
        {
        }

        public void Error(string message)
        {
        }

        public void Error(string message, Exception exception)
        {
        }

        public void Fatel(string message)
        {
        }

        public void Fatel(string message, Exception exception)
        {
        }

        public void Info(string message)
        {
        }

        public void Info(string message, Exception exception)
        {
        }

        public void Warn(string message)
        {
        }

        public void Warn(string message, Exception exception)
        {
        }
    }
}
