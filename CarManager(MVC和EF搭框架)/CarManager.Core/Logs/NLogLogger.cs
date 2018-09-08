using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace CarManager.Core.Logs
{
    /// <summary>
    /// Log4的日志
    /// </summary>
    public class NLogLogger : ILogger
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Debug(string message, Exception exception)
        {
            logger.Debug(exception.Message, message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Error(string message, Exception exception)
        {
            logger.Error(exception.Message, message);
        }

        public void Fatel(string message)
        {
            logger.Fatal(message);
        }

        public void Fatel(string message, Exception exception)
        {
            logger.Fatal(exception.Message,message);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Info(string message, Exception exception)
        {
            logger.Info(exception.Message,message);
        }

        public void Warn(string message)
        {
            logger.Warn(message);
        }

        public void Warn(string message, Exception exception)
        {
            logger.Warn(exception.Message,message);
        }
    }
}
