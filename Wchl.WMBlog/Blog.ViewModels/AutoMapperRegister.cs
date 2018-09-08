using Blog.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Unity;

namespace Blog.ViewModels
{
    /// <summary>
    /// 注册AutoMapper
    /// </summary>
    public class AutoMapperRegister : IDependencyRegister
    {
        public void RegisterTypes(IUnityContainer container)
        {
            var profileTypes = this.GetType().Assembly.GetTypes().Where(t => typeof(Profile).IsAssignableFrom(t));
            //映射器都是单例
            var profileInstances = profileTypes.Select(t => (Profile) Activator.CreateInstance(t));
            //添加进映射配置
            var config=new MapperConfiguration(cfg => { profileInstances.ToList().ForEach(p=>cfg.AddProfile(p));});

            container.RegisterInstance<MapperConfiguration>(config);
            container.RegisterInstance<IMapper>(config.CreateMapper());
        }
    }
}
