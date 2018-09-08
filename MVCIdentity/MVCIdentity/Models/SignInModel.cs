using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCIdentity.Models
{
    /// <summary>
    /// 登录
    /// </summary>
    public class SignInModel
    {

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "记住我")]
        public bool RememberMe { get; set; }
    }
}