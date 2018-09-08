using Domain;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceImp
{
    class UserManage : RepositoryBase<Domain.SYS_USER>, IUserManage
    {
        /// <summary>
        /// 获取用户名
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetUserName(int userId)
        {
            var query = LoadAll(a=>a.ID==userId);
            if (query == null || !query.Any())
            {
                return "";
            }
            return query.First().NAME;

        }
        /// <summary>
        /// 判断是否是管理员
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool IsAdmin(int userId)
        {
            //暂时没有加入角色
            return true;
        }
        /// <summary>
        /// 用户登录处理
        /// </summary>
        /// <param name="useraccount"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public SYS_USER UserLogin(string useraccount, string password)
        {
            var entity = this.Get(p=>p.ACCOUNT==useraccount);
            if (entity!=null&&entity.PASSWORD==password)//使用加密的话就先将密码解密在进行对比
            {
                return entity;
            }
            return null;
        }
    }
}
