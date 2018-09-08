using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Common.Json
{
    /// <summary>
    /// 序列化
    /// </summary>
    public class SerializeByJsonNet
    {
        /// <summary>
        /// 序列化对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] serialize(object obj)
        {
            if (obj == null)
            {
                return default(byte[]);
            }
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            return Encoding.UTF8.GetBytes(jsonString);
        }

        /// <summary>
        /// 反序列化:将一个字符串转为对象（这里使用JsonNet）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T Deserialize<T>(byte[] value) where T : class
        {
            if (value == null)
            {
                return default(T);
            }
            var jsonString = Encoding.UTF8.GetString(value);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);
        }

    }
}
