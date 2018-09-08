using Blog.Common;
using Blog.Domain;
using Blog.IRepository;
using Blog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.IRepository.ISysRepository;
using Blog.Repository.SysRepository;
using Unity;

namespace RepositoryRegister
{
    /// <summary>
    /// 仓储层注入
    /// </summary>
    public class RepositoryRegister : IDependencyRegister
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IDbContext, BlogDbContext>();//最后括号里可指定生命周期
            container.RegisterType(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            container.RegisterType<ISysUserInfoRepository, SysUserInfoRepository>();
        }
    }
}
