using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarManager.Web.Models.Cars;
using CarManager.WebCore;
using FluentValidation;

namespace CarManager.Web.Validation
{
    /// <summary>
    /// car的模型验证
    /// </summary>
    public class CarValidator:AbstractValidator<CarViewModel>
    {
        //验证规则
        public CarValidator()
        {
            RuleFor(car => car.Name).NotNull().Length(5, 10);//链式写法
            RuleFor(c => c.Email).EmailAddress();
        }
    }
}