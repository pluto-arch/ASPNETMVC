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
    public class SysExceptionService : ISysExceptionService
    {
        private const string _expcacheKey = nameof(SysExceptionService) + nameof(SysExceptions);//缓存的键值
        private ICacheManager _cache;
        private readonly ISysExceptionRepository _expDal;

        public SysExceptionService(ISysExceptionRepository dal, ICacheManager cache)

        {
            this._cache = cache;
            this._expDal = dal;
        }

        public List<SysExceptions> GetAll()
        {
            if (_cache.IsExist(_expcacheKey))
            {
                return _cache.Get<List<SysExceptions>>(_expcacheKey);
            }
            else
            {
                var list = _expDal.GetAll();
                _cache.Set(_expcacheKey, list, new TimeSpan(0, 0, 10, 0));//缓存10分钟
                return list;
            }
        }

        public List<SysExceptions> GetList(ref GridPager pager, string queryStr)
        {
            List<SysExceptions> query = null;
            IQueryable<SysExceptions> list = null;
            list = GetAll().AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                list = list.Where(a => a.Message.Contains(queryStr) || a.Message.Contains(queryStr));
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

        public List<SysExceptions> QueryByPage<TKey>(int pageIndex, int pagesize, out int rowcount, Expression<Func<SysExceptions, bool>> predicate, Expression<Func<SysExceptions, TKey>> keySelector, bool isQueryOrderBy)
        {
            return _expDal.QueryByPage(predicate, pageIndex, pagesize, out rowcount, keySelector, isQueryOrderBy);
        }

        public List<SysExceptions> QueryWhere(Expression<Func<SysExceptions, bool>> expression)
        {
            if (_cache.IsExist(_expcacheKey))
            {
                List<SysExceptions> list = _cache.Get<List<SysExceptions>>(_expcacheKey);
                return list.AsQueryable().Where(expression).ToList();

            }
            else
            {
                var list = _expDal.GetAll();
                _cache.Set(_expcacheKey, list, new TimeSpan(0, 0, 10, 0));//缓存10分钟
                return _expDal.QueryWhere(expression);
            }
        }


        public int AddException(ref ValidationErrors error, SysExceptions ex)
        {
            int result = 0;
            try
            {
                result= _expDal.AddExceptoon(ex);
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
