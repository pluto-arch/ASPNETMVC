using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Common.Cache
{
    /// <summary>
    /// 空缓存
    /// </summary>
    public class NullCacheManager : ICacheManager
    {
        public void Clear()
        {
            
        }

        public T Get<T>(string key) where T : class
        {
            return default(T);
        }

        public bool IsExist(string key)
        {
            return false;
        }

        public void Remove(string key)
        {
            
        }

        public void Set(string key, object value, TimeSpan cacheTime)
        {
            
        }
      
    }
}
