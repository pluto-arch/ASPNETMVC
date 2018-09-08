using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace 注册登录.Models
{
    public enum Cities
    {
        LONDON, PARIS, CHICAGO
    }

    public class AppUser: IdentityUser
    {
        //放置自定义的属性
        public Cities City { get; set; }
    }
}