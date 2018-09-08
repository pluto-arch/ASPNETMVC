using System.Web;
using System.Web.Mvc;
using Blog.WebCore;
using Blog.WebCore.Filters;

namespace Blog.WebUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
