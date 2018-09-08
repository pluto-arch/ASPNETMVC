using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Blog.Common;

namespace Blog.IService
{
    /// <summary>
    /// 基础服务类
    /// </summary>
    public interface IBaseService<T> where T:class
    {
        #region 查询
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();
            /// <summary>
        /// 简单的条件查询
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        List<T> QueryWhere(Expression<Func<T,bool>> expression);
        /// <summary>
        /// 多表联合查询
        /// </summary>
        /// <param name="expression">主查询表达式</param>
        /// <param name="tableNames">联合的表名</param>
        /// <returns></returns>
        List<T> QueryJoin(Expression<Func<T,bool>> expression,string[] tableNames);
        /// <summary>
        /// 按条件升降序查询
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="expression"></param>
        /// <param name="keySelector"></param>
        /// <param name="isQueryOrderBy"></param>
        /// <returns></returns>
        List<T> QueryOrderBy<TKey>(Expression<Func<T, bool>> expression, Expression<Func<T, bool>> keySelector,
            bool isQueryOrderBy);
        /// <summary>
        /// 分页查询带升降序
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pagesize"></param>
        /// <param name="rowcount"></param>
        /// <param name="predicate"></param>
        /// <param name="keySelector"></param>
        /// <param name="IsQueryOrderBy"></param>
        /// <returns></returns>
        List<T> QueryByPage<TKey>(int pageIndex, int pagesize, out int rowcount, Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> keySelector, bool IsQueryOrderBy);
        #endregion

        #region 编辑
        /// <summary>
        /// 简单编辑
        /// </summary>
        /// <param name="t"></param>
        void Edit(ref ValidationErrors error, T t);
        /// <summary>
        /// 编辑部分字段
        /// </summary>
        /// <param name="t"></param>
        /// <param name="propertys"></param>
        void Edit(ref ValidationErrors error, T t, string[] propertys);
        #endregion

        #region 删除
        /// <summary>
        /// 条件删除
        /// </summary>
        /// <param name="expression"></param>
        void Delete(ref ValidationErrors error, Expression<Func<T,bool>> expression);
        /// <summary>
        /// 直接删除
        /// </summary>
        /// <param name="t"></param>
        void Delete(ref ValidationErrors error, T t,bool isadded);
        #endregion

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        bool Add(ref ValidationErrors error, T t);
        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        int SaveChanges(ref ValidationErrors error);
        /// <summary>
        /// 调用存储过程返回指定结果集 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="sql"></param>
        /// <param name="pamrs"></param>
        /// <returns></returns>
        List<TResult> RunProc<TResult>(ref ValidationErrors error, string sql, params object[] pamrs);
    }
}
