using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;
using CarManager.Data.Domain;

namespace CarManager.Data
{
    /// <summary>
    /// EF数据库上下文  继承自接口
    /// CarDbContext是我们项目中的数据库上下文，继承自接口可以与EF解耦和，方便扩展
    /// </summary>
    public class CarDbContext : DbContext,IDbContext
    {
        static CarDbContext()
        {
            System.Data.Entity.Database.SetInitializer(new CreateDatabaseIfNotExists<CarDbContext>());
        }

        public CarDbContext():base("CarManagerDB")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();//创建表时移除复数名称
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());//就是把当前程序集中的mapping全部加载，前提是mapping中的类实现了EntityTypeConfiguration这个配置类
            base.OnModelCreating(modelBuilder);
        }
        public int ExcuteSqlCommand(string sql, params object[] param)
        {
            return Database.ExecuteSqlCommand(sql,param);
        }
        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }
    }
}
