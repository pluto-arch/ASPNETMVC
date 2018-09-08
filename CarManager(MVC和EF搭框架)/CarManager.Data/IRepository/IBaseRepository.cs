using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Data.IRepository
{
    /// <summary>
    /// 基础的增删该查
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T> where T:class
    {
        /// <summary>
        /// 获取T类型的全部实体
        /// </summary>
        /// <returns></returns>
        List<T> Get();
        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(object id);
        /// <summary>
        /// 插入一个实体,返回插入的这个新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Insert(T entity);
        /// <summary>
        /// 更新一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Update(T entity);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="expression">lambda表达式</param>
        /// <returns></returns>
        bool Delete(Expression<Func<T,bool>> expression);
    }
}
