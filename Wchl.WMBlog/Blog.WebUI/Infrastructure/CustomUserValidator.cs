using System;
using System.Collections.Generic;
using System.Data.Entity.Utilities;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Blog.WebUI.Models;
using Microsoft.AspNet.Identity;

namespace Blog.WebUI.Infrastructure
{
    public class CustomUserValidator: UserValidator<AppUser>
    {
        public CustomUserValidator(AppUserManager mgr) : base(mgr)
        {
        }

        public override async Task<IdentityResult> ValidateAsync(AppUser item)
        {
            if ((object)item == null)
                throw new ArgumentNullException(nameof(item));
            List<string> errors = new List<string>();
            await this.ValidateUserName(item, errors).WithCurrentCulture();
            return errors.Count <= 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }
        private async Task ValidateUserName(AppUser user, List<string> errors)
        {
            await base.ValidateAsync(user);
            if (string.IsNullOrWhiteSpace(user.UserName))
                errors.Add(string.Format((IFormatProvider)CultureInfo.CurrentCulture, "不能为空", new object[1]
                {
                    (object) "Name"
                }));
        }
    }
}