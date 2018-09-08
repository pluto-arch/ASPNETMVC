using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    interface IUserManage: IRepository<Domain.SYS_USER>
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="useraccount"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Domain.SYS_USER UserLogin(string useraccount, string password);
        /// <summary>
        /// 验证是否为管理员
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool IsAdmin(int userId);
        /// <summary>
        /// 根据用户ID获取用户名，不存在返回空
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        string GetUserName(int userId);
    }
}
