using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    /// <summary>
    /// SysUserInfo视图模型
    /// </summary>
    public class SysUserInfoViewModel
    {
        public int Id { get; set; }

        [DisplayName("登录名")]
        public string ULoginName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        [DisplayName("密码")]
        public string ULoginPwd { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        [DisplayName("真实姓名")]
        public string URealName { get; set; }
        /// <summary>
        /// 状态 1：正常，0：不正常
        /// </summary>
        [DisplayName("状态")]
        public int? UState { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("备注")]
        public string URemark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime UCreateTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [DisplayName("更新时间")]
        public DateTime? UUpdateTime { get; set; }
    }
}
