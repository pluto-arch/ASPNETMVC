using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configs
{
    /// <summary>
    /// 连接字符串的提取
    /// 字符串对应应用程序中的配置文件
    /// 模型对应Domain中的数据库模型Context.cs构造函数
    /// </summary>
    public class MyConfig:wkmvc_dbEntities
    {
        /// <summary>
        /// 封装EF实体
        /// </summary>
        public System.Data.Entity.DbContext _db { get; private set; }

        public MyConfig()
        {
            _db = new wkmvc_dbEntities();//实例化当前程序中的EF上下文
        }
        #region 连接数据库配置
        public static string DefaultConnectionString = "";//默认连接字符串
        /// <summary>
        /// 通用数据库连接配置
        /// </summary>
        public static IDbConnection DefaultConnection
        {
            get {
                IDbConnection defaultconn = null;
                string action = ConfigurationManager.AppSettings["daoType"];
                switch (action)
                {
                    case "mssql":
                        defaultconn = new System.Data.SqlClient.SqlConnection();
                        DefaultConnectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
                        break;
                }
                return defaultconn;
            }
        }
        /// <summary>
        /// 构造数据库连接字符串 注：数据库切换要修改
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public static string DataBaseConnectionString(string entityName)
        {
            IDbConnection con = DefaultConnection;
            return EFConnectionStringModle(entityName,DefaultConnectionString);
        }
        /// <summary>
        /// 构造EF使用数据库连接字符串
        /// </summary>
        /// <param name="EntityName">数据库上下文</param>
        /// <param name="DBsoure">数据库连接字符串</param>
        /// <returns></returns>
        static string EFConnectionStringModle(string EntityName, string DBsoure)
        {
            return string.Concat("metadata=res://*/",EntityName, ".csdl|res://*/", EntityName, ".ssdl|res://*/", EntityName, ".msl;provider=System.Data.SqlClient;provider connection string='", DBsoure, "'");
        }
        #endregion

        #region SQL拦截器
        /// <summary>
        /// 配置EF执行SQL拦截器
        /// </summary>
        //public static void EFTracingConfig(log4net.ILog log4net)
        //{
        //    //注册拦截器
        //    EFTracingProviderConfiguration.RegisterProvider();
        //    //SQL日志
        //    log4net.ILog log = null;
        //    bool isdebug = (ConfigurationManager.AppSettings["isdebug"] == "true");
        //    if (isdebug)
        //    {
        //        log = log4net;
        //    }
        //    EFTracingProviderConfiguration.LogToLog4net = log;
        //}
        #endregion

    }
}
