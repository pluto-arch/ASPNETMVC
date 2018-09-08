using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain
{
    /// <summary>
    /// 项目数据库上下文
    /// </summary>
    public class BlogDbContext:DbContext,IDbContext
    {
        public new DbContextConfiguration Configuration
        {
            get { return base.Configuration; }
        }

        public new Database Database
        {
            get { return base.Database; }
        }

        public BlogDbContext():base("name=BlogDB")
        {
            
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//移除表名复数
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());//自动添加实现了EntityTypeConfiguration<TEntity>的类
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return Database.ExecuteSqlCommand(sql, parameters);
        }
        /// <summary>
        /// 返回一个结果集
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

        DbEntityEntry IDbContext.Entry<TEntity>(TEntity t)
        {
            return base.Entry(t);
        }
    }
}
