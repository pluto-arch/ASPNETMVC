using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using CarManager.WebCore;
using CarManager.WebCore.MvcExtension;
using FluentValidation;
using FluentValidation.Mvc;
using FluentValidation.Validators;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CarManager.Web.App_Start.ExensionsActivator), "Start")]
namespace CarManager.Web.App_Start
{
    public static class ExensionsActivator
    {
        public static void Start()
        {
            FluentValidationModelValidatorProvider.Configure();
            ValidatorOptions.DisplayNameResolver = (type, memberInfo, LambdaExpression) =>
            {
                string propName = type.Name+memberInfo.Name+"DisplayName";
                string displayName = WebMessage.ResourceManager.GetString(propName);
                return displayName;
            };
            ValidatorOptions.PropertyNameResolver= (type, memberInfo, LambdaExpression) =>
            {
                string propName = type.Name + memberInfo.Name + "ErrorText";
                string displayName = WebMessage.ResourceManager.GetString(propName);
                return displayName;
            };

            //替换MVC的元数据提供者
            ModelMetadataProviders.Current = new CustomModelMetadataProvider();
            //DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            //ModelValidatorProviders.Providers.Insert(0, new FluentValidationModelValidatorProvider());
        }
    }
}