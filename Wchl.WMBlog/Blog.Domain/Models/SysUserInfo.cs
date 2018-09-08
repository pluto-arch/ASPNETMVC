using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Models
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class SysUserInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UId { get; set; }
        /// <summary>
        /// 登录账号
        /// </summary>
        public string ULoginName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string ULoginPwd { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string URealName { get; set; }
        /// <summary>
        /// 状态 1：正常，0：不正常
        /// </summary>
        public int? UState { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string URemark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime UCreateTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UUpdateTime { get; set; }

    }
}
