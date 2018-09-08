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
    /// unity����
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container

        /// <summary>
        /// ��ȡ���úõ�unity����
        /// </summary>
        /// <returns></returns>
        public static IUnityContainer GetConfigurationContainer()
        {
            //��ע��
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
           
            container.RegisterInstance(container);//��ע������

            ITypeFinder typeFinder=new WebTypeFinder();//web bin������

            var config = ConfigurationManager.GetSection("applicationConfig") as ApplicationConfig;//��ȡ���ý�
            container.RegisterInstance<ApplicationConfig>(config);//ע�������ļ��Զ�������ý�

            //ֻҪ��ʵ����IDependencyRegister�Ķ�ע�����
            //ͨ������
            var registerTypes = typeFinder.FindClassesOfType<IDependencyRegister>();//�鷲��ʵ����IDependencyRegister��dll
            foreach (var registerType in registerTypes)
            {
                var  register=(IDependencyRegister)Activator.CreateInstance(registerType);//��������ʵ��
                register.RegisterTypes(container);//���ö����ע�뷽��(��һ��������ȥ)
            }


        }
    }
}