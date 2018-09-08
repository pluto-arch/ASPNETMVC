using Blog.Common.Cache;
using Blog.IRepository;
using Blog.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Blog.Common;
using Blog.Service.Core;

namespace Blog.Service
{
    public class BaseServices<T>:IBaseService<T> where T:class 
    {

        public IBaseRepository<T> _baseDal;

        public ICacheManager _cache;

        public string cacheKey;
        
        #region 查询

        public List<T> GetAll()
        {
            if (_cache.IsExist(cacheKey))
            {
                return _cache.Get<List<T>>(cacheKey);
            }
            else
            {
                var list = _baseDal.GetAll();
                _cache.Set(cacheKey,list,new TimeSpan(0,0,10,0));//缓存10分钟
                return list;
            }
        }
        /// <summary>
        /// 简单条件查询
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public List<T> QueryWhere(Expression<Func<T, bool>> expression)
        {
            return _baseDal.QueryWhere(expression);
        }
        /// <summary>
        /// 多表联合查询
        /// 有主外键关系
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="tableNames"></param>
        /// <returns></returns>
        public List<T> QueryJoin(Expression<Func<T, bool>> expression, string[] tableNames)
        {
            return _baseDal.QueryJoin(expression, tableNames);
        }
        /// <summary>
        /// 升序or降序查询
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="expression"></param>
        /// <param name="keySelector"></param>
        /// <param name="isQueryOrderBy"></param>
        /// <returns></returns>
        public List<T> QueryOrderBy<TKey>(Expression<Func<T, bool>> expression, Expression<Func<T, bool>> keySelector,
            bool isQueryOrderBy)
        {
            return _baseDal.QueryByOrder(expression, keySelector, isQueryOrderBy);
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pagesize"></param>
        /// <param name="rowcount"></param>
        /// <param name="predicate"></param>
        /// <param name="keySelector"></param>
        /// <param name="IsQueryOrderBy"></param>
        /// <returns></returns>
        public List<T> QueryByPage<TKey>(int pageIndex, int pagesize, out int rowcount,
            Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> keySelector, bool IsQueryOrderBy)
        {
            return _baseDal.QueryByPage(predicate,pageIndex,pagesize,out rowcount,keySelector,IsQueryOrderBy);
        }
        #endregion

        #region 编辑
        /// <summary>
        /// 普通编辑
        /// </summary>
        /// <param name="t"></param>
        public void Edit(ref ValidationErrors error, T t)
        {
            try
            {
                _cache.Remove(cacheKey);
                _baseDal.Edit(t);
            }
            catch (Exception e)
            {
               error.Add(e.Message);
               ExceptionHander.WriteException(e);
            }
           
        }
        /// <summary>
        /// 编辑部分字段
        /// </summary>
        /// <param name="t"></param>
        /// <param name="propertys"></param>
        public void Edit(ref ValidationErrors error, T t, string[] propertys)
        {
            try
            {
                _cache.Remove(cacheKey);
                _baseDal.Edit(t, propertys);
            }
            catch (Exception e)
            {
                error.Add(e.Message);
                ExceptionHander.WriteException(e);
            }
            
        }
        #endregion

        #region 删除
        /// <summary>
        /// 条件删除
        /// </summary>
        /// <param name="expression"></param>
        public void Delete(ref ValidationErrors error, Expression<Func<T, bool>> expression)
        {
            try
            {
                _cache.Remove(cacheKey);
                _baseDal.Delete(expression);
            }
            catch (Exception e)
            {
                error.Add(e.Message);
                ExceptionHander.WriteException(e);
            }
          
        }
        /// <summary>
        /// 普通删除
        /// </summary>
        /// <param name="t"></param>
        /// <param name="isadded"></param>
        public void Delete(ref ValidationErrors error, T t,bool isadded)
        {
            try
            {
                _cache.Remove(cacheKey);
                _baseDal.Delect(t, isadded);
            }
            catch (Exception e)
            {
                error.Add(e.Message);
                ExceptionHander.WriteException(e);
            }
           
        }
        #endregion
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        public bool Add(ref ValidationErrors error, T t)
        {
            bool result = false;
            try
            {
                _cache.Remove(cacheKey);
                if (_baseDal.Add(t)!=null)
                {
                    result= true;
                }
            }
            catch (Exception e)
            {
                result = false;
                error.Add(e.Message);
                ExceptionHander.WriteException(e);
            }
            return result;

        }
        /// <summary>
        /// 统一提交
        /// </summary>
        /// <returns></returns>
        public int SaveChanges(ref ValidationErrors error)
        {
            int result = 0;
            try
            {
                result= _baseDal.SaverChanges();
            }
            catch (Exception e)
            {
                error.Add(e.Message);
                ExceptionHander.WriteException(e);
            }
            return result;
        }
        /// <summary>
        /// 调用存储过程返回一个指定的TResult
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="sql"></param>
        /// <param name="pamrs"></param>
        /// <returns></returns>
        public List<TResult> RunProc<TResult>(ref ValidationErrors error, string sql, params object[] pamrs)
        {
            List<TResult> list=new List<TResult>();
            try
            {
                list= _baseDal.RunProc<TResult>(sql, pamrs);
            }
            catch (Exception e)
            {
                error.Add(e.Message);
                ExceptionHander.WriteException(e);
            }

            return list;
        }
    }
}
