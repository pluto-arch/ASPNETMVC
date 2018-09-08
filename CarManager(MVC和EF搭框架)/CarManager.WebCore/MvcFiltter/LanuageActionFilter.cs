using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CarManager.WebCore.MvcFiltter
{
    public class LanuageActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string lg = filterContext.RouteData.Values["lg"].ToString();
            System.Threading.Thread.CurrentThread.CurrentUICulture=new CultureInfo(lg);
            Thread.CurrentThread.CurrentCulture=new CultureInfo(lg);
        }
    }
}
