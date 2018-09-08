using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json.Serialization;

namespace CarManager.WebCore.MvcExtension
{
    public class JsonNetResult:JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            if (context==null)
            {
                throw  new ArgumentNullException(nameof(context));
            }

            var response = context.HttpContext.Response;

            response.ContentType = !string.IsNullOrEmpty(ContentType)?ContentType:"application/json";

            if (ContentEncoding!=null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            //序列化设置
            var jsonSerializerSetting = new JsonSerializerSettings
            {
                //日期格式处理
                DateFormatString = "yyyy-mm-dd HH:mm:ss",
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var json= JsonConvert.SerializeObject(Data, Formatting.None, jsonSerializerSetting);
            response.Write(json);

        }
    }
}
