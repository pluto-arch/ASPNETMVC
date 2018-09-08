using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Common.Cache
{
    /// <summary>
    /// 内存缓存
    /// </summary>
    public class MemoryCacheManager : ICacheManager
    {
        /// <summary>
        /// 清空缓存
        /// </summary>
        public void Clear()
        {
            //MemoryCache.Default获取到的是缓存集合(可遍历的)
            foreach (var item in MemoryCache.Default)
            {
                this.Remove(item.Key);
            }
        }
        /// <summary>
        /// 得到一个缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key) where T : class
        {
            return MemoryCache.Default.Get(key) as T;
        }
        /// <summary>
        /// 判断缓存是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsExist(string key)
        {
            return MemoryCache.Default.Contains(key);
        }
        /// <summary>
        /// 移除一个缓存
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            MemoryCache.Default.Remove(key);
        }
        /// <summary>
        /// 添加一个缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cacheTime"></param>
        public void Set(string key, object value, TimeSpan cacheTime)
        {
            MemoryCache.Default.Add(key, value, new CacheItemPolicy() { SlidingExpiration = cacheTime });
        }

    }
}
