using System.Web;
using System.Web.Mvc;
using CarManager.WebCore.MvcFiltter;

namespace CarManager.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LanuageActionFilter());
            
        }
    }
}
