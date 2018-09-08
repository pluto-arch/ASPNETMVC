using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace 注册登录.Infrastructure
{
    public class LocationClaimsProvider
    {
        /// <summary>
        /// 自定义的声明信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static IEnumerable<Claim> GetClaims(ClaimsIdentity user)
        {
            List<Claim> claims = new List<Claim>();
            if (user.Name.ToLower() == "alice")
            {
                claims.Add(CreateClaim(ClaimTypes.DateOfBirth, "2018-02-03"));
                claims.Add(CreateClaim(ClaimTypes.StateOrProvince, "DC"));
            }
            else
            {
                claims.Add(CreateClaim(ClaimTypes.DateOfBirth, "2010-02-03"));
                claims.Add(CreateClaim(ClaimTypes.StateOrProvince, "NY"));
            }
            return claims;
        }

        private static Claim CreateClaim(string type, string value)
        {
            return new Claim(type, value, ClaimValueTypes.String, "RemoteClaims");
        }
    }
}