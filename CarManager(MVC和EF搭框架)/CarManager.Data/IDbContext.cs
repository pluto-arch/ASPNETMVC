using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Data
{
    /// <summary>
    /// 数据库上下文接口（为了解耦和）
    /// 里面可以有很多操作
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// 实体集
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        /// <summary>
        /// 保存      
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        int ExcuteSqlCommand(string sql,params object[] param);
    }
}
