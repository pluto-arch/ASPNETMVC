using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using MVCIdentity.Models;

namespace MVCIdentity.Infrastructure
{
    public class ApplicationSignInManager:SignInManager<ApplicationUser,string>
    {
        public ApplicationSignInManager(ApplicationUserManager usermanager,IAuthenticationManager authmanager):base(usermanager,authmanager)
        {
            
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationUserManager> options,IOwinContext context )
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(),context.Authentication);
        }
    }
}