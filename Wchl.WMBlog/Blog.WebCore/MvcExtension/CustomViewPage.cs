using System.Web.Mvc;
using Blog.WebCore.Properties;

namespace Blog.WebCore.MvcExtension
{
    /// <summary>
    /// 自定义视图按钮等等的文字语言或者其他
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public abstract class CustomViewPage<TModel>:WebViewPage<TModel>
    {
        public string SetBtnText(string keyCode)
        {
            //这里可以从资源中查找
            string text= Resources.ResourceManager.GetString(keyCode);
            return Resources.ResourceManager.GetString(keyCode);
        }
    }
}
