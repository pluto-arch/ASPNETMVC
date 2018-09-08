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
        
        // additional properties will go here
        // 这里将放置附加属性
        public int Sort { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        public DateTime? BirthDateTime { get; set; }
        [MaxLength(100)]
        public string ImgUrl { get; set; }//头像图片
        [MaxLength(30)]
        public string NickName { get; set; }
        [MaxLength(200)]
        public string Country { get; set; }
        [MaxLength(200)]
        public string ProvinceOrState { get; set; }
        [MaxLength(200)]
        public string City { get; set; }
        /// <summary>
        /// 个人标签
        /// </summary>
        [MaxLength(100)]
        public string Tab { get; set; }
        [MaxLength(500)]
        public string Remark { get; set; }
        
        public bool? Gender { get; set; }
        public int? Age { get; set; }
        [MaxLength(500)]
        public string WebUrl { get; set; }
    }

}