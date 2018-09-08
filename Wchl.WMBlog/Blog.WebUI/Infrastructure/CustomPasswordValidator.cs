using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Blog.WebUI.Infrastructure
{
    public class CustomPasswordValidator:PasswordValidator
    {
        public override Task<IdentityResult> ValidateAsync(string pass)
        {
            if (pass == null)
                throw new ArgumentNullException(nameof(pass));
            List<string> stringList = new List<string>();
            if (string.IsNullOrWhiteSpace(pass) || pass.Length < this.RequiredLength)
                stringList.Add(string.Format((IFormatProvider)CultureInfo.CurrentCulture, "密码长度不够", new object[1]
                {
                    (object) this.RequiredLength
                }));
            if (this.RequireNonLetterOrDigit && pass.All<char>(new Func<char, bool>(this.IsLetterOrDigit)))
                stringList.Add("密码要求是数字与字母的组合");
            if (this.RequireDigit && pass.All<char>((Func<char, bool>)(c => !this.IsDigit(c))))
                stringList.Add("密码要包含数字");
            if (this.RequireLowercase && pass.All<char>((Func<char, bool>)(c => !this.IsLower(c))))
                stringList.Add("密码要求有小写字母");
            if (this.RequireUppercase && pass.All<char>((Func<char, bool>)(c => !this.IsUpper(c))))
                stringList.Add("密码要求有大写字母");
            if (pass.Contains("123456"))
            {
                stringList.Add("密码太简单");
            }
            if (stringList.Count == 0)
                return Task.FromResult<IdentityResult>(IdentityResult.Success);
            return Task.FromResult<IdentityResult>(IdentityResult.Failed(string.Join(" ", (IEnumerable<string>)stringList)));

        }
    }
}