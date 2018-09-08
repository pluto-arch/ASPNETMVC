using System;
using System.Configuration;
using Blog.Common;
using Blog.Common.ConfigManager;
using Blog.IService.ISysServices;
using Blog.WebCore;
using Blog.WebUI.Infrastructure;
using Unity;
using Unity.Lifetime;

namespace Blog.WebUI
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container

        public static IUnityContainer GetConfigurationContainer()
        {
            RegisterTypes(BaseUnityRegister.Current);
            return BaseUnityRegister.Current;
        }
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterInstance(container);

            //注入自定义的配置文件
            var config = ConfigurationManager.GetSection("applicationConfig") as ApplicationConfig;
            container.RegisterInstance<ApplicationConfig>(config);

            ITypeFinder typeFinder = new WebTypeFinder();//web bin查找器
            //只要是实现了IDependencyRegister的都注册进来
            //通过反射
            var registerTypes = typeFinder.FindClassesOfType<IDependencyRegister>();//查凡是实现了IDependencyRegister的dll
            foreach (var registerType in registerTypes)
            {
                var register = (IDependencyRegister)Activator.CreateInstance(registerType);//遍历创建实例
                register.RegisterTypes(container);//调用对象的注入方法(传一个容器过去)
            }
            container.RegisterInstance<LogHandler>(new LogHandler(container.Resolve<ILogService>()),new ContainerControlledLifetimeManager());//注册实例
        }
    }
}