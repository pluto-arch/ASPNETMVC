using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Blog.WebCore.MvcExtension
{
    /// <summary>
    /// @HTML扩展
    /// </summary>
    public static class ExtendMvcHtml
    {
        /// <summary>
        /// 按钮生成
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="id">控件Id</param>
        /// <param name="icon">控件icon图标class</param>
        /// <param name="text">控件的名称</param>
        /// <param name="hr">分割线</param>
        /// <returns></returns>
        public static MvcHtmlString ToolButton(this HtmlHelper helper, string id, string icon, string text, bool hr)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<a id=\"{0}\" class=\"btn btn-default\">", id);
            sb.AppendFormat("<span class=\"{0}\"></span>&nbsp;{1}</a>", icon, text);
            return new MvcHtmlString(sb.ToString());

        }
    }
}
