using Blog.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Blog.WebCore
{
    public class WebTypeFinder : AppDomainTypeFinder
    {
        /// <summary>
        /// bin下程序集是否已经被加载
        /// </summary>
        private bool binFolderAssembliesLoaded = false;
        /// <summary>
        /// 获取web下的bin目录
        /// </summary>
        /// <returns></returns>
        public virtual string GetBinDirectory()
        {
            if (System.Web.Hosting.HostingEnvironment.IsHosted)
            {
                return System.Web.HttpRuntime.BinDirectory;
            }
            else
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }
        }

        public override IList<Assembly> GetAssemblies()
        {
            if (!binFolderAssembliesLoaded)
            {
                binFolderAssembliesLoaded = true;
                LoadMatchingAssemblies(GetBinDirectory());
            }

            return base.GetAssemblies();
        }

    }
}
