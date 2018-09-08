using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Common.ConfigManager
{
    /// <summary>
    /// 自定义ConfigurationSection(配置节)
    /// </summary>
    public class ApplicationConfig:ConfigurationSection
    {
        /// <summary>
        /// 对应配置文件中的元素
        /// </summary>
        private const string RedisCacheConfigProperty = "redisConfig";

        [ConfigurationProperty(RedisCacheConfigProperty, IsRequired = true)] //加限定  IsRequired表示必须
        public RedisCacheElement RedisCacheConfig
        {
            get => (RedisCacheElement)base[RedisCacheConfigProperty];
            set => base[RedisCacheConfigProperty] = value;
        }
    }
}
