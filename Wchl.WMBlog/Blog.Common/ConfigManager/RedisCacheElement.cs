using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Common.ConfigManager
{
    /// <summary>
    /// 自定义配置节下的元素
    /// </summary>
    public class RedisCacheElement:ConfigurationElement
    {
        /// <summary>
        /// 配置文件中对应配置节的属性名称
        /// </summary>
        private const string EnablePropertyName = "enable";
        /// <summary>
        /// 配置文件中Redis连接字符串属性名称
        /// </summary>
        private const string ConnectionStringProperty = "connectionString";

        /// <summary>
        /// 读取或设置配置值
        /// </summary>
        [ConfigurationProperty(EnablePropertyName, IsRequired = true)] //加限定  IsRequired表示必须
        public bool Enable
        {
            get { return (bool)base[EnablePropertyName]; }
            set { base[EnablePropertyName] = value; }
        }
        [ConfigurationProperty(ConnectionStringProperty, IsRequired = true)]
        public string ConnectionString
        {
            get { return (string)base[ConnectionStringProperty]; }
            set { base[ConnectionStringProperty] = value; }
        }
    }
}
