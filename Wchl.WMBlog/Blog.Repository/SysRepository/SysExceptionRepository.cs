using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain;
using Blog.Domain.Models;
using Blog.IRepository.ISysRepository;

namespace Blog.Repository.SysRepository
{
    /// <summary>
    /// 系统异常仓储
    /// </summary>
    public class SysExceptionRepository : ISysExceptionRepository
    {
        #region 注入

        private readonly IDbContext _db;
        private IDbSet<SysExceptions> _dbset;

        public virtual IDbSet<SysExceptions> DbSet
        {
            get { return this._dbset = this._dbset ?? _db.Set<SysExceptions>(); }
        }

        public SysExceptionRepository(IDbContext db)
        {
            this._db = db;
        }
        #endregion

        public int AddExceptoon(SysExceptions ex)
        {
            DbSet.Add(ex);
            return _db.SaveChanges();
        }

        public bool Delete(Expression<Func<SysExceptions, bool>> expression)
        {
            var list=DbSet.Where(expression).ToList();
            foreach (var item in list)
            {
                DbSet.Remove(item);
            }
            return _db.SaveChanges() > 0 ? true : false;
        }

        public List<SysExceptions> GetAll()
        {
            return DbSet.ToList();
        }

        public IQueryable<SysExceptions> GetList()
        {
            return DbSet.AsQueryable();
        }

        public List<SysExceptions> QueryByPage<Tkey>(Expression<Func<SysExceptions, bool>> expression, int pageIndex, int pagesize, out int rowcount, Expression<Func<SysExceptions, Tkey>> keySelector, bool isQueryOrderBy)
        {
            rowcount = DbSet.Count(expression);
            if (isQueryOrderBy)
            {
                return DbSet.Where(expression).OrderBy(keySelector).Skip((pageIndex - 1) * pagesize).Take(pagesize).ToList();
            }
            else
            {
                return DbSet.Where(expression).OrderByDescending(keySelector).Skip((pageIndex - 1) * pagesize)
                    .Take(pagesize).ToList();
            }
        }

        public List<SysExceptions> QueryWhere(Expression<Func<SysExceptions, bool>> expression)
        {
            return DbSet.Where(expression).ToList();
        }
    }
}
