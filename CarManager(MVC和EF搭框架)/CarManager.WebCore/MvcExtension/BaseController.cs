using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CarManager.WebCore.MvcExtension
{
    /// <summary>
    /// 自定义controller父类
    /// </summary>
    public class BaseController:Controller
    {
        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonNetResult(){Data = data,ContentType = contentType,ContentEncoding = contentEncoding,JsonRequestBehavior = behavior};
        }
    }
}
