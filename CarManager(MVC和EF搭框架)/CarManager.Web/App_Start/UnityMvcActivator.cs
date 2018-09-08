using System.Linq;
using System.Web.Mvc;

using Unity.AspNet.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CarManager.Web.UnityMvcActivator), nameof(CarManager.Web.UnityMvcActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(CarManager.Web.UnityMvcActivator), nameof(CarManager.Web.UnityMvcActivator.Shutdown))]

namespace CarManager.Web
{
    /// <summary>
    /// UnityMVC�ļ�����.
    /// ��global��start����ǰ�ͻ�ִ��
    /// </summary>
    public static class UnityMvcActivator
    {
        /// <summary>
        /// Integrates Unity when the application starts.
        /// </summary>
        public static void Start()
        {
            var container = UnityConfig.GetConfigurationContainer();//��unity�����ļ���ȡ���ú��˵�����
            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            // TODO: Uncomment if you want to use PerRequestLifetimeManager
            // Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));
        }

        /// <summary>
        /// Disposes the Unity container when the application is shut down.
        /// </summary>
        public static void Shutdown()
        {
            var container = UnityConfig.GetConfigurationContainer();
            container.Dispose();
        }
    }
}