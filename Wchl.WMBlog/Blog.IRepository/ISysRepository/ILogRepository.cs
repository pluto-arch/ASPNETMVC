using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Models;

namespace Blog.IRepository.ISysRepository
{
    public interface ILogRepository
    {
        /// <summary>
        /// 得到全部
        /// </summary>
        /// <returns></returns>
        List<SysLogs> GetAll();
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        List<SysLogs> QueryWhere(Expression<Func<SysLogs, bool>> expression);
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
        List<SysLogs> QueryByPage<Tkey>(Expression<Func<SysLogs, bool>> expression, int pageIndex, int pagesize, out int rowcount, Expression<Func<SysLogs, Tkey>> keySelector, bool isQueryOrderBy);


        IQueryable<SysLogs> GetList();



        #region 新增和删除

        int AddLog(SysLogs log);

        bool Delete(Expression<Func<SysLogs,bool>> expression);

        #endregion


    }
}
