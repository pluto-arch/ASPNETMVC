using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Blog.Common;
using Blog.Common.Cache;
using Blog.Domain.Models;
using Blog.IRepository.ISysRepository;
using Blog.IService.ISysServices;
using Blog.Service.Core;

namespace Blog.Service.SysServices
{
    public class LogServices : ILogService
    {
        
        private const string _logcacheKey = nameof(LogServices) + nameof(SysLogs);//缓存的键值
        private ICacheManager _cache;
        private readonly ILogRepository _logDal;

        public LogServices(ILogRepository logDal, ICacheManager cache)

        {
            this._cache = cache;
            this._logDal = logDal;
        }

        /// <summary>
        /// 得到全部
        /// </summary>
        /// <returns></returns>
        public List<SysLogs> GetAll()
        {
            if (_cache.IsExist(_logcacheKey))
            {
                return _cache.Get<List<SysLogs>>(_logcacheKey);
            }
            else
            {
                var list = _logDal.GetAll();
                _cache.Set(_logcacheKey, list, new TimeSpan(0, 0, 10, 0));//缓存10分钟
                return list;
            }
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public List<SysLogs> QueryWhere(Expression<Func<SysLogs, bool>> expression)
        {
            if (_cache.IsExist(_logcacheKey))
            {
                List<SysLogs> list = _cache.Get<List<SysLogs>>(_logcacheKey);
                return list.AsQueryable().Where(expression).ToList();
            }
            else
            {
                var list = _logDal.GetAll();
                _cache.Set(_logcacheKey, list, new TimeSpan(0, 0, 10, 0));//缓存10分钟
                return _logDal.QueryWhere(expression);
            }

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
        public List<SysLogs> QueryByPage<TKey>(int pageIndex, int pagesize, out int rowcount,
            Expression<Func<SysLogs, bool>> predicate, Expression<Func<SysLogs, TKey>> keySelector, bool isQueryOrderBy)
        {
            return _logDal.QueryByPage(predicate, pageIndex, pagesize, out rowcount, keySelector, isQueryOrderBy);
        }

        //普通分页
        public List<SysLogs> GetList(ref GridPager pager, string queryStr)
        {
            List<SysLogs> query = null;
            IQueryable<SysLogs> list = null;
            list = GetAll().AsQueryable();
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                list = list.Where(a => a.Message.Contains(queryStr) || a.Module.Contains(queryStr));
                pager.totalRows = list.Count();
            }
            else
            {
                pager.totalRows = list.Count();
            }
            if (pager.order == "desc")
            {
                query = list.OrderByDescending(c => c.CreateTime).Skip((pager.page - 1) * pager.rows).Take(pager.rows).ToList();
            }
            else
            {
                query = list.OrderBy(c => c.CreateTime).Skip((pager.page - 1) * pager.rows).Take(pager.rows).ToList();
            }
            return query;
        }
        

        public int AddLog(ref ValidationErrors error, SysLogs log)
        {
            int result = 0;
            try
            {
                result= _logDal.AddLog(log);
            }
            catch (Exception e)
            {
                error.Add(e.Message);
                ExceptionHander.WriteException(e);
            }

            return result;
        }
    }
}
