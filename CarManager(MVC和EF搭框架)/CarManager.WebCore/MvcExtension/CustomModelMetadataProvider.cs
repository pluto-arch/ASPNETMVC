using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;

namespace CarManager.WebCore.MvcExtension
{
    /// <summary>
    /// 自定义元数据提供者
    /// 
    /// </summary>
    public class CustomModelMetadataProvider:DataAnnotationsModelMetadataProvider
    {
        /// <summary>
        /// 功能，从资源中找Viewmodel的display(显示)值
        /// </summary>
        /// <param name="attributes"></param>
        /// <param name="containerType"></param>
        /// <param name="modelAccessor"></param>
        /// <param name="modelType"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType,
            string propertyName)
        {
            var modelMetadata= base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);

            if (containerType!=null)
            {
                //资源的Key
                string propName = containerType.Name.Replace(".", string.Empty) + propertyName + nameof(modelMetadata.DisplayName);
                string displayName= WebMessage.ResourceManager.GetString(propName);
                if (!string.IsNullOrWhiteSpace(displayName))
                {
                    modelMetadata.DisplayName = displayName;
                }
                
            }
            return modelMetadata;
        }
    }
}
