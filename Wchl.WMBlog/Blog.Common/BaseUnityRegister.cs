using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Blog.Common
{
    public class BaseUnityRegister
    {
        /// <summary>
        /// 延迟加载，在首次需要用到的时候才加载
        /// 构造函数传递一个容器
        /// </summary>
        static Lazy<IUnityContainer> unityContainer = new Lazy<IUnityContainer>(() => new UnityContainer());

        /// <summary>
        /// 当前的容器对象
        /// </summary>
        public static IUnityContainer Current
        {
            get { return unityContainer.Value; }
        }
        /// <summary>
        /// 解析一个
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>() where T : class
        {
            return unityContainer.Value.Resolve<T>();
        }
        /// <summary>
        /// 全部解析
        /// 一个接口可能有多个实现
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> ResolveAll<T>() where T : class
        {
            return unityContainer.Value.ResolveAll<T>();
        }
    }
}
