using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Blog.WebUI.Models;

namespace Blog.WebUI.Infrastructure
{
    /*
     *
     *  这里是测试  没啥用了
     *
     *
     */


    /// <summary>
    /// 声明（Claims）可以直接根据用户已知的信息对用户进行授权，这能够保证当数据发生变化时，授权也随之而变。此事最简单的做法是根据用户数据来生成Role声明（Claim），然后由控制器用来限制对动作方法的访问
    ///
    /// 
    /// </summary>
    public class ClaimsRoles
    {
        public static IEnumerable<Claim> CreateRolesFromClaims(ClaimsIdentity user,AppUser loginUser)
        {
            List<Claim> claims = new List<Claim>();
            if (user.HasClaim(x => x.Type == ClaimTypes.StateOrProvince&& x.Issuer == "RemoteClaims" && x.Value == "DC")&& user.HasClaim(x => x.Type == ClaimTypes.Role
                                      && x.Value == "Administrators"))
            {
                claims.Add(new Claim(ClaimTypes.Role, "DCStaff"));//只要用户的声明（Claims）承认他们是DCStaff角色的成员，那么他们便能访问OtherAction动作。该角色的成员是动态生成的，因此，若是用户的雇用状态或地点信息发生变化，也会改变他们的授权等级。
            }
            return claims;
        }
    }
}