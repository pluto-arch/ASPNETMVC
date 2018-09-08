using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Blog.IRepository
{
    /// <summary>
    /// 仓储基础
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepository<TEntity> where TEntity:class
    {
#region 查询
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        List<TEntity> GetAll();
            /// <summary>
        /// 查询结果集
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        List<TEntity> QueryWhere(Expression<Func<TEntity,bool>> expression);
        /// <summary>
        /// 多表联合查询
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        List<TEntity> QueryJoin(Expression<Func<TEntity, bool>> expression,string[] tableNames);
        /// <summary>
        /// 升序还是降序查
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="keySelector"></param>
        /// <param name="isQueryOrderBy"></param>
        /// <returns></returns>
        List<TEntity> QueryByOrder(Expression<Func<TEntity, bool>> expression,
            Expression<Func<TEntity, bool>> keySelector, bool isQueryOrderBy);
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
        List<TEntity> QueryByPage<Tkey>(Expression<Func<TEntity,bool>> expression,int pageIndex,int pagesize,out int rowcount,Expression<Func<TEntity,Tkey>> keySelector,bool isQueryOrderBy);
        #endregion

        #region 编辑
        /// <summary>
        /// 修改实体，或者部分字段修改
        /// </summary>
        /// <param name="t"></param>
        /// <param name="propertys"></param>
        bool Edit(TEntity t, string[] propertys);
        /// <summary>
        /// 直接修改
        /// </summary>
        /// <param name="t"></param>
        bool Edit(TEntity t);

        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="expression">一个表达式</param>
        bool Delete(Expression<Func<TEntity,bool>> expression);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isadded"></param>
        bool Delect(TEntity model,bool isadded);

        #endregion

        #region 新增
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="model"></param>
        TEntity Add(TEntity model);
        #endregion

        /// <summary>
        /// EF持久化到数据库
        /// </summary>
        /// <returns></returns>
        int SaverChanges();
        /// <summary>
        /// 调用存储过程返回一个指定的结果集
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="sql"></param>
        /// <param name="pamrs"></param>
        /// <returns></returns>
        List<TResult> RunProc<TResult>(string sql, params object[] pamrs);
    }
}
