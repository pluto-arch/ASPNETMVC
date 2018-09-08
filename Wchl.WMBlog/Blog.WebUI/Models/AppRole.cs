using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Blog.WebUI.Models
{
    /// <summary>
    /// 角色
    /// </summary>
    public class AppRole : IdentityRole
    {

        public AppRole() : base() { }

        public AppRole(string name) : base(name) { }

        public DateTime? CreateTime { get; set; }
        [MaxLength(300)]
        public string Remark { get; set; }

        public bool? State { get; set; }
        [MaxLength(200)]
        public string ParentId { get; set; }

    }
}