using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 注册登录.Models
{
    public class CreateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

    /// <summary>
    /// 用户登陆模型
    /// </summary>
    public class LoginModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }



    /*
     * RoleEditModel类使我能够在系统中传递角色细节和用户细节，按成员进行归类。我在视图模型中使用了AppUser对象，以使我在编辑成员的视图中能够为每个用户提取用户名和ID。RoleModificationModel类是在用户递交他们的修改时，从模型绑定系统接收到的一个类。它含有用户ID的数组，而不是AppUser对象，这是对角色成员进行修改所需要的。
     */

    /// <summary>
    /// 角色编辑模型
    /// </summary>
    public class RoleEditModel
    {
        public AppRole Role { get; set; }
        public IEnumerable<AppUser> Members { get; set; }
        public IEnumerable<AppUser> NonMembers { get; set; }
    }
    /// <summary>
    /// 角色修改模型
    /// </summary>
    public class RoleModificationModel
    {
        [Required]
        public string RoleName { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }
    }
}