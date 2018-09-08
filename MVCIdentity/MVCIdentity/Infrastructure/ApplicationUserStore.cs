using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using MVCIdentity.Models;

namespace MVCIdentity.Infrastructure
{
    public class ApplicationUserStore:UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationDbContext context):base(context)
        {
            
        }
    }
}