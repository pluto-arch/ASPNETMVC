using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain
{
    public interface IDbContext
    {
        DbContextConfiguration Configuration { get; }
        Database Database { get; }

        /// <summary>
        /// 一个实体
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        /// <summary>
        /// 持久化到数据库
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        int ExecuteSqlCommand(string sql, params object[] parameters);
        DbEntityEntry Entry<TEntity>(TEntity t) where TEntity : class;
    }
}
