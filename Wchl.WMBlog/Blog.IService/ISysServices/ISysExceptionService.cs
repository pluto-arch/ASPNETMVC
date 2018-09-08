using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Blog.Common;
using Blog.Domain.Models;

namespace Blog.IService.ISysServices
{
    public interface ISysExceptionService
    {
        /// <summary>
        /// 得到全部
        /// </summary>
        /// <returns></returns>
        List<SysExceptions> GetAll();
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        List<SysExceptions> QueryWhere(Expression<Func<SysExceptions, bool>> expression);

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
        List<SysExceptions> QueryByPage<TKey>(int pageIndex, int pagesize, out int rowcount,
            Expression<Func<SysExceptions, bool>> predicate, Expression<Func<SysExceptions, TKey>> keySelector,
            bool isQueryOrderBy);
        /// <summary>
        /// 普通分页
        /// </summary>
        /// <param name="pager"></param>
        /// <param name="queryStr"></param>
        /// <returns></returns>
        List<SysExceptions> GetList(ref GridPager pager, string queryStr);


        int AddException(ref ValidationErrors error, SysExceptions ex);
    }
}
