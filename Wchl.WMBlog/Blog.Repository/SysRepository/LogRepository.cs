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
    public class LogRepository : ILogRepository
    {
        #region 注入
        private new readonly IDbContext _db;
        private IDbSet<SysLogs> _dbset;
        protected virtual IDbSet<SysLogs> Dbset
        {
            get { return this._dbset = this._dbset ?? _db.Set<SysLogs>(); }
        }
        public LogRepository(IDbContext db)
        {
            this._db = db;
        }
        #endregion

        public List<SysLogs> GetAll()
        {
            return Dbset.ToList();
        }
        /// <summary>
        /// 分页升序或分页降序
        /// </summary>
        /// <param name="expression">查询表达式</param>
        /// <param name="pageIndex">第几页</param>
        /// <param name="pagesize">一页多少条</param>
        /// <param name="rowcount">总记录数</param>
        /// <param name="keySelector">排序字段</param>
        /// <param name="isQueryOrderBy">true为升序，反之降序</param>
        /// <returns></returns>
        public List<SysLogs> QueryByPage<Tkey>(Expression<Func<SysLogs, bool>> expression, int pageIndex, int pagesize, out int rowcount, Expression<Func<SysLogs, Tkey>> keySelector, bool isQueryOrderBy)
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

        public List<SysLogs> QueryWhere(Expression<Func<SysLogs, bool>> expression)
        {
            return Dbset.Where(expression).ToList();
        }

        public int AddLog(SysLogs log)
        {
            Dbset.Add(log);
            return _db.SaveChanges();
        }

        public bool Delete(Expression<Func<SysLogs, bool>> expression)
        {
            return _db.SaveChanges() > 0 ? true:false;
        }

        public IQueryable<SysLogs> GetList()
        {
            return Dbset.AsQueryable();
        }
    }
}
