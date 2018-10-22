using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Blog.WebUI.Models
{
    public class AppUser : IdentityUser
    {
        
        /// <summary>
        /// 排序号
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        [MaxLength(100)]
        public string DisplayName { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? BirthDateTime { get; set; }


        /// <summary>
        /// 性别
        /// </summary>
        public bool? Gender { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int? Age { get; set; }
        /// <summary>
        /// 个人链接
        /// </summary>
        [MaxLength(300)]
        public string WebUrl { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        [MaxLength(100)]
        public string ImgUrl { get; set; }//头像图片
        /// <summary>
        /// 国家
        /// </summary>
        [MaxLength(200)]
        public string Country { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        [MaxLength(200)]
        public string ProvinceOrState { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        [MaxLength(200)]
        public string City { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(500)]
        public string Remark { get; set; }

        /// <summary>
        /// qq号
        /// </summary>
        [MaxLength(20)]
        public string QqNumber { get; set; }
        /// <summary>
        /// 微信号
        /// </summary>
        [MaxLength(30)]
        public string WeChat { get; set; }
 
    }

}