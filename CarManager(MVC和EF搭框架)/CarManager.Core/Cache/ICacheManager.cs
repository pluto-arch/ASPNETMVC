using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Core.Cache
{
    /// <summary>
    /// 缓存管理规范
    /// </summary>
    public interface ICacheManager
    {
        /// <summary>
        /// 根据key获取缓存
        /// </summary>
        /// <typeparam name="T">缓存存的数据类型</typeparam>
        /// <param name="key">缓存键值</param>
        /// <returns></returns>
        T Get<T>(string key) where T : class;
        /// <summary>
        /// 添加一个缓存
        /// </summary>
        /// <param name="key">缓存键值</param>
        /// <param name="value">缓存的数据</param>
        /// <param name="cacheTime">缓存有效时间</param>
        void Set(string key,object value,TimeSpan cacheTime);
        /// <summary>
        /// 判断一个缓存是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool IsExist(string key);
        /// <summary>
        /// 移除缓存
        /// </summary>
        void Remove(string key);
        /// <summary>
        /// 清空缓存
        /// </summary>
        void Clear();
    }
}
