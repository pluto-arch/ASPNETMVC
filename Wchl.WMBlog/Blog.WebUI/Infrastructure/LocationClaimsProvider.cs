using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Blog.WebUI.Models;
using Microsoft.AspNet.Identity;

namespace Blog.WebUI.Infrastructure
{
    /// <summary>
    /// 本地声明提供者
    /// </summary>
    public static class LocationClaimsProvider
    {
        public static IEnumerable<Claim> GetClaims(ClaimsIdentity user,AppUser loginUser)
        {
            List<Claim> claims = new List<Claim>();
            if (user.Name.ToLower() == "admin")
            {

                //GetClaims方法以ClaimsIdentity为参数，并使用Name属性创建了关于用户ZIP码（邮政编码）和州府的声明（Claims）
                claims.Add(CreateClaim("Country", "中国"));
                claims.Add(CreateClaim("City", "上海"));
                claims.Add(CreateClaim(ClaimTypes.Role, "SuperAdmin"));//如果是zhangyulong登录。则给zhangyulong动态添加成绩管理员角色
            }
            else
            {
                claims.Add(CreateClaim("Country", "中国"));
                claims.Add(CreateClaim("City", "上海"));
            }
            return claims;
        }

        private static Claim CreateClaim(string type, string value)
        {
            return new Claim(type, value, ClaimValueTypes.String, "System");
        }
    }
}