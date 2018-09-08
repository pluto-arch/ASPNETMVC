using CarManager.Core.Infrastucture;
using System;
using System.ComponentModel.Design;
using System.Configuration;
using CarManager.Core.Configs;
using CarManager.WebCore.Infrastucture;
using Unity;

namespace CarManager.Web
{
    /// <summary>
    /// unity配置
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container

        /// <summary>
        /// 获取配置好的unity容器
        /// </summary>
        /// <returns></returns>
        public static IUnityContainer GetConfigurationContainer()
        {
            //先注册
            RegisterTypes(ServicesContiner.Current);
            return ServicesContiner.Current;
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
           
            container.RegisterInstance(container);//先注册容器

            ITypeFinder typeFinder=new WebTypeFinder();//web bin查找器

            var config = ConfigurationManager.GetSection("applicationConfig") as ApplicationConfig;//读取配置节
            container.RegisterInstance<ApplicationConfig>(config);//注册配置文件自定义的配置节

            //只要是实现了IDependencyRegister的都注册进来
            //通过反射
            var registerTypes = typeFinder.FindClassesOfType<IDependencyRegister>();//查凡是实现了IDependencyRegister的dll
            foreach (var registerType in registerTypes)
            {
                var  register=(IDependencyRegister)Activator.CreateInstance(registerType);//遍历创建实例
                register.RegisterTypes(container);//调用对象的注入方法(传一个容器过去)
            }


        }
    }
}