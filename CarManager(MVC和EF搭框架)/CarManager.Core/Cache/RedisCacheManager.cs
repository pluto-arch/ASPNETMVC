using CarManager.Core.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace CarManager.Core.Cache
{
    /// <summary>
    /// Redis缓存
    /// </summary>
    public class RedisCacheManager : ICacheManager
    {
        /// <summary>
        /// redis连接字符串
        /// </summary>
        private readonly string redisConnectionString ;
        /// <summary>
        /// redis连接对象
        /// volatile修饰的数据 优化器在用到这个变量时必须每次都小心地重新读取这个变量的值，而不是使用保存在寄存器里的备份（保证每次取到的都是最新的）
        /// </summary>
        private volatile ConnectionMultiplexer redisConnection;//redis连接  应为是连接，资源有限，所以得加锁，只用长连接。
        /// <summary>
        /// 给有限访问资源加锁
        /// </summary>
        private readonly object redisConnectionLock = new object();

        public RedisCacheManager(ApplicationConfig config)
        {
            if (string.IsNullOrWhiteSpace(config.RedisCacheConfig.ConnectionString))
            {
                throw new ArgumentNullException("redis argument is empty",nameof(config));
            }
            this.redisConnectionString = config.RedisCacheConfig.ConnectionString;
            this.redisConnection = GetRedisConn();
        }
        /// <summary>
        /// 得到redis连接对象
        /// </summary>
        /// <returns></returns>
        private ConnectionMultiplexer GetRedisConn()
        {
            if (this.redisConnection != null)
            {
                if (this.redisConnection.IsConnected)
                {
                    //如果redisConnection已经有了，并且是连接状态，直接返回
                    return redisConnection;
                }
                else
                {
                    this.redisConnection.Dispose();//释放资源
                }
            }
            lock (redisConnectionLock)//加锁操作
            {
                this.redisConnection = ConnectionMultiplexer.Connect(redisConnectionString);//新建redis连接 
            }
            return this.redisConnection;
        }
        /// <summary>
        /// 清空所有缓存
        /// </summary>
        public void Clear()
        {
            //redis有可能是分布式缓存，每个key为终结点概念
            foreach (var endPoint in this.GetRedisConn().GetEndPoints())
            {
                var server = this.GetRedisConn().GetServer(endPoint);//得到每个服务器上的数据
                foreach (var key in server.Keys())
                {
                    redisConnection.GetDatabase().KeyDelete(key);
                }
            }
        }
        /// <summary>
        /// 得到一个redis缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key) where T : class
        {
            var value = redisConnection.GetDatabase().StringGet(key);
            if (value.HasValue)
            {
                //redis缓存的都是字符串所以得进行转化
                ///反序列化
                return SerializeByJsonNet.Deserialize<T>(value);
            }
            else
            {
                return default(T);
            }
        }
        /// <summary>
        /// 是否存在某个缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsExist(string key)
        {
            return redisConnection.GetDatabase().KeyExists(key);
        }
        /// <summary>
        /// 移除一个缓存
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            redisConnection.GetDatabase().KeyDelete(key);
        }
        /// <summary>
        /// 添加一个缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cacheTime"></param>
        public void Set(string key, object value, TimeSpan cacheTime)
        {
            if (value!=null)
            {
                redisConnection.GetDatabase().StringSet(key, SerializeByJsonNet.serialize(value),cacheTime);
            }
        }
    }
}
