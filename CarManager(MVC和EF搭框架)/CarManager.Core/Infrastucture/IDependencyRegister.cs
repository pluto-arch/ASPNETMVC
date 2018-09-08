using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace CarManager.Core.Infrastucture
{
    /// <summary>
    /// 自定义的注入
    /// 使得各层分层注入
    /// </summary>
    public interface IDependencyRegister
    {
        /// <summary>
        /// 注入类型
        /// </summary>
        /// <param name="container">一个容器</param>
        void RegisterTypes(IUnityContainer container);
    }
}
