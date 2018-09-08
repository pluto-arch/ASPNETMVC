using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Blog.Common;
using Blog.Common.Json;
using Blog.Domain.Models;
using Blog.ViewModels;
using Blog.ViewModels.ViewModels;
using Blog.WebUI.Core;
using Blog.WebUI.Infrastructure;
using Blog.WebUI.Models;
using Blog.WebUI.Models.UserModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Blog.WebUI.Areas.Adm.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class RoleController : BaseController
    {

        /// <summary>
        /// 下拉列表模型
        /// </summary>
        class Rlist
        {
            public string name { get; set; }
            public string value { get; set; }
            public string selected { get; set; }
            public string Disable { get; set; }
        }

        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetList(string page = "1", string limit = "10")
        {
            var rolelist = RoleManager.Roles.ToList();
            int currpage = int.Parse(page);
            int limits = int.Parse(limit);
            var rolepage = rolelist.Skip((currpage - 1) *limits).Take(limits).ToList();
           
           
            List<SysRoleViewModel> resultList = new List<SysRoleViewModel>();
            foreach (var r in rolepage)
            {
                SysRoleViewModel model=new SysRoleViewModel();
                model.Id = r.Id;
                model.Name = r.Name;
                model.CreateTime = r.CreateTime;
                model.State = r.State;
                model.Remark = r.Remark;
                if (r.Users.Count>0)
                {
                    string unames = "";
                    foreach (var u in r.Users)
                    {
                        string uid = u.UserId;
                        Task<AppUser> user=UserManager.FindByIdAsync(uid);
                        unames += "["+user.Result.UserName+"],";
                    }
                    unames = unames.TrimEnd(',');
                    model.UserNames = unames;
                }
                else
                {
                    model.UserNames = "未分配用户";
                }

                if (!string.IsNullOrWhiteSpace(r.ParentId))
                {
                    AppRole parentRole = RoleManager.FindById(r.ParentId);
                    if (parentRole!=null)
                    {
                        model.ParentId = parentRole.Name;
                    }
                    else
                    {
                        model.ParentId = "0级角色";
                    }
                }
                resultList.Add(model);
            }

            var json = new
            {
                code = 0,
                msg = "",
                count = rolelist.Count,
                data = resultList.ToArray()
            };
            return Json(json);
        }


        [Authorize]
        public JsonResult GetRoleList()
        {
            string code1 = "1";//code为0时, 表示正常, 不为0时则提示msg信息
            string msg1 = "";

            IQueryable<AppRole> roles = RoleManager.Roles;
            if (roles.Count() > 0)
            {
                code1 = "0";
            }

            var json = new
            {
                code = code1,
                msg = msg1,
                data = (from u in roles
                        select new Rlist()
                        {
                        name = u.Name,
                        value = u.Id,
                        selected = "",
                        Disable = "",
                        })
            };
            return Json(json);
        }

        public JsonResult GetDetail(string id="")
        {
            var role = RoleManager.FindById(id);
            SysRoleViewModel model = new SysRoleViewModel();
            string unames = "";
            int result = 0;
            if (role!=null)
            {
                result = 1;
                model.Id = role.Id;
                model.Name = role.Name;
                model.CreateTime = role.CreateTime;
                model.State = role.State;
                model.ParentId = role.ParentId;
                model.Remark = role.Remark;
                if (role.Users.Count > 0)
                {
                    foreach (var u in role.Users)
                    {
                        string uid = u.UserId;
                        Task<AppUser> user = UserManager.FindByIdAsync(uid);
                        unames += "[" + user.Result.UserName + "],";
                    }
                    unames = unames.TrimEnd(',');
                    model.UserNames = unames;
                }
                else
                {
                    model.UserNames = "未分配用户";
                }
            }
            else
            {
                result = 0;
            }
            var json = new
            {
                result=result,
                data=model
            };

            return Json(json);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Create(string Name="",string State="",string UserNames="",string Remark="",string ParentId="")
        {
            bool isEnable = true;//默认启用
            switch (State)
            {
                case "on":
                    isEnable = true;
                    break;
                case "off":
                    isEnable = false;
                    break;
            }

            string[] unames = UserNames.Split(',');
            AppRole newRole = new AppRole();
            newRole.CreateTime=DateTime.Now;
            newRole.ParentId = ParentId;
            newRole.Remark = Remark;
            newRole.State = isEnable;
            newRole.Name = Name;
            IdentityResult result= await RoleManager.CreateAsync(newRole);//先创建角色
            if(result.Succeeded)
            {
                for (int i = 0; i < unames.Length; i++)
                {
                    UserManager.AddToRole(unames[i], Name);//将所选用户加入角色
                }
                return Json(JsonHandler.CreateMessage(1, "创建成功"), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, "创建失败"), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            AppRole role = await RoleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await RoleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error", result.Errors);
                }
            }
            else
            {
                return View("Error", new string[] { "Role Not Found" });
            }
        }

        public async Task<ActionResult> Edit(string id)
        {
            AppRole role = await RoleManager.FindByIdAsync(id);
            string[] memberIDs = role.Users.Select(x => x.UserId).ToArray();
            IEnumerable<AppUser> members
                = UserManager.Users.Where(x => memberIDs.Any(y => y == x.Id));
            IEnumerable<AppUser> nonMembers = UserManager.Users.Except(members);
            return View(new RoleEditModel
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }

        [HttpPost]
        public async Task<ActionResult> Edit(RoleModificationModel model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.IdsToAdd ?? new string[] { })
                {
                    result = await UserManager.AddToRoleAsync(userId, model.RoleName);
                    if (!result.Succeeded)
                    {
                        return View("Error", result.Errors);
                    }
                }
                foreach (string userId in model.IdsToDelete ?? new string[] { })
                {
                    result = await UserManager.RemoveFromRoleAsync(userId,
                        model.RoleName);
                    if (!result.Succeeded)
                    {
                        return View("Error", result.Errors);
                    }
                }
                return RedirectToAction("Index");
            }
            return View("Error", new string[] { "Role Not Found" });
        }



        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}