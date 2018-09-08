using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Core.Configs
{
    /// <summary>
    /// 自定义配置节的解析
    /// </summary>
    public class ApplicationConfig: ConfigurationSection
    {
        private const string RedisCacheConfigProperty = "redisCache";

        [ConfigurationProperty(RedisCacheConfigProperty, IsRequired = true)] //加限定  IsRequired表示必须
        public RedisCacheElement RedisCacheConfig
        {
            get => (RedisCacheElement)base[RedisCacheConfigProperty];
            set => base[RedisCacheConfigProperty] = value;
        }
    }
}
