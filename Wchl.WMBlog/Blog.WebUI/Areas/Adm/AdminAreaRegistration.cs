using System.Web.Mvc;

namespace Blog.WebUI.Areas.Adm
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Adm";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.MapRoute(
                "Admin_default",
                "Adm/{controller}/{action}/{id}",
                new { controller="Default",action = "Main", id = UrlParameter.Optional },
                new string[] { "Blog.WebUI.Areas.Adm.Controllers" }
            );
        }
    }
}