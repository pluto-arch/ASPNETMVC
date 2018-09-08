using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.WebCore.IdentityExtension
{
    public enum Gender
    {
        male=1,
        
        Female=0,

        Secret=2
    }

    /// <summary>
    /// 自定义的用户
    /// </summary>
    public class BlogUsers
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public Gender? Gender { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadImg { get; set; }
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
