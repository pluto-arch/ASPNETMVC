using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CarManager.Web.Validation;
using FluentValidation.Attributes;

namespace CarManager.Web.Models.Cars
{
    [Validator(typeof(CarValidator))]
    public class CarViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime? CreateTime { get; set; }
        [Display(Name = "邮箱")]
        public string Email { get; set; }
    }
}