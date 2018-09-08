using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCIdentity.Models
{
    /// <summary>
    /// 注册
    /// </summary>
    public class SignUpModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password",ErrorMessage = "Password Error")]
        public string ConfirmPassword { get; set; }
    }
}