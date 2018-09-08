using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace 注册登录.Infrastructure
{
    public class ClaimsRoles
    {
        //RemoteClaims发行者（Issuer），值为DC。也检查用户是否具有Role声明（Claim），其值为Employees。如果用户这两个声明都有，那么便返回一个DCStaff角色的Role声明
        public static IEnumerable<Claim> CreateRolesFromClaims(ClaimsIdentity user)
        {
            List<Claim> claims = new List<Claim>();
            if (user.HasClaim(x => x.Type == ClaimTypes.StateOrProvince&& x.Issuer == "RemoteClaims" && x.Value == "DC")
                && user.HasClaim(x => x.Type == ClaimTypes.Role&& x.Value == "Employees"))
            {
                claims.Add(new Claim(ClaimTypes.Role, "DCStaff"));
            }
            return claims;
        }
    }
}