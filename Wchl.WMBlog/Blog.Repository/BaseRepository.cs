using Blog.Domain;
using Blog.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository
{
    /// <summary>
    /// 仓储基础的实现
    /// </summary>
    public class BaseRepository<TEntity>:IBaseRepository<TEntity> where TEntity:class 
    {
        
        public IDbContext _db;
     

        private IDbSet<TEntity> _dbset;
        protected virtual IDbSet<TEntity> Dbset
        {
            get { return this._dbset = this._dbset ?? _db.Set<TEntity>(); }
        }


        #region 查询

        public List<TEntity> GetAll()
        {
            return Dbset.ToList();
        }
        public List<TEntity> QueryWhere(Expression<Func<TEntity, bool>> expression)
        {
            return Dbset.Where(expression).ToList();
        }
        /// <summary>
        /// 多表联合查询
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="tableNames"></param>
        /// <returns></returns>
        public List<TEntity> QueryJoin(Expression<Func<TEntity, bool>> expression, string[] tableNames)
        {
            if (tableNames==null&&tableNames.Any()==false)
            {
                throw new Exception("缺少连表名称");
            }

            DbQuery<TEntity> query = Dbset as DbQuery<TEntity>;
            foreach (var table in tableNames)
            {
                query = query.Include(table);
            }

            return query.Where(expression).ToList();

        }

        public List<TEntity> QueryByOrder(Expression<Func<TEntity, bool>> expression,Expression<Func<TEntity, bool>> keySelector, bool isQueryOrderBy)
        {
            if (isQueryOrderBy)
            {
                return Dbset.Where(expression).OrderBy(keySelector).ToList();
            }

            return Dbset.Where(expression).OrderByDescending(keySelector).ToList();
        }

        public List<TEntity> QueryByPage<TKey>(Expression<Func<TEntity, bool>> expression, int pageIndex, int pagesize,
            out int rowcount, Expression<Func<TEntity, TKey>> keySelector, bool isQueryOrderBy)
        {
            rowcount = Dbset.Count(expression);
            if (isQueryOrderBy)
            {
                return Dbset.Where(expression).OrderBy(keySelector).Skip((pageIndex - 1) * pagesize).Take(pagesize)
                    .ToList();
            }
            else
            {
                return Dbset.Where(expression).OrderByDescending(keySelector).Skip((pageIndex - 1) * pagesize)
                    .Take(pagesize).ToList();
            }
        }

        #endregion

        #region 编辑

        public bool Edit(TEntity t, string[] propertys)
        {
            if (t==null)
            {
                throw new Exception("实体不能为空");
            }

            if (propertys.Any()==false)
            {
                throw new Exception("要修改的属性至少一个");
            }

            DbEntityEntry entry = _db.Entry(t);
            entry.State = EntityState.Unchanged;
            foreach (var item in propertys)
            {
                entry.Property(item).IsModified = true;
            }
            //关闭对实体数据合法性验证
            _db.Configuration.ValidateOnSaveEnabled = false;
           return _db.SaveChanges()>0;

        }

        public bool Edit(TEntity t)
        {
            _db.Entry(t).State = EntityState.Modified;
            return _db.SaveChanges() > 0;
        }
        #endregion

        #region 删除

        public bool Delete(Expression<Func<TEntity, bool>> expression)
        {
            var delList= Dbset.Where(expression).ToList();
            if (delList.Count>0)
            {
                foreach (var item in delList)
                {
                    Dbset.Remove(item);
                }

                return _db.SaveChanges() > 0;
            }
            else
            {
                throw new Exception("删除条件有误");
            }
        }

        public bool Delect(TEntity model, bool isadded)
        {
            if (!isadded)
            {
                Dbset.Attach(model);
            }

            Dbset.Remove(model);
            return _db.SaveChanges() > 0;
        }

        #endregion

        #region 新增

        public TEntity Add(TEntity model)
        {
            var obj=Dbset.Add(model);
            if (model==null)
            {
                return null;
            }
            if (_db.SaveChanges()>0)
            {
                return obj;
            }
            return null;
        }


        #endregion

        /// <summary>
        /// 统一提交
        /// </summary>
        /// <returns></returns>
        public int SaverChanges()
        {
            return _db.SaveChanges();
        }
        /// <summary>
        /// 调用存储过程返回一个指定的TResult
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="sql"></param>
        /// <param name="pamrs"></param>
        /// <returns></returns>
        public List<TResult> RunProc<TResult>(string sql, params object[] pamrs)
        {
            return _db.Database.SqlQuery<TResult>(sql, pamrs).ToList();
        }

    }
}
