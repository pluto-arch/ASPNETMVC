using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Common.Json;
using Blog.WebUI.Core;
using Blog.WebUI.Models;
using Microsoft.AspNet.Identity;

namespace Blog.WebUI.Areas.Adm.Controllers
{
    public class UserController : BaseController
    {
        /// <summary>
        /// 下拉列表模型
        /// </summary>
        class Ulist
        {
            public string name { get; set; }
            public string value { get; set; }
            public string selected { get; set; }
            public string Disable { get; set; }
        }


        [Authorize]
        public JsonResult GetUserList()
        {
            string code1 = "1";//code为0时, 表示正常, 不为0时则提示msg信息
            string msg1 = "";

            IQueryable<AppUser> users = UserManager.Users;
            if (users.Count()>0)
            {
                code1 = "0";
            }

            var json = new
            {
                code=code1,
                msg=msg1,
                data=(from u in users
                      select new Ulist()
                        {
                            name =u.UserName,
                            value = u.Id,
                            selected = "",
                            Disable = "",
                        })
            };
            return Json(json);
        }

        /// <summary>
        /// 更新个人信息
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public JsonResult UpdateOwnMessage(string id,string firstname, string lastname,string gender,string age,string birthday,string nickname,string email,string address
        ,string weburl,string tab,string phone)
        {
            try
            {
                bool sex = true;
                switch (gender)
                {
                    case "0":
                        sex = false;
                        break;
                    case "1":
                        sex = true;
                        break;;
                }
                AppUser user = UserManager.FindById(id);
                if (user!=null)
                {
                    try
                    {
                        user.Age = int.Parse(age);
                    }
                    catch
                    {
                        user.Age = 0;
                    }

                    try
                    {
                        user.BirthDateTime = DateTime.Parse(birthday);
                    }
                    catch
                    {}

                    string[] addressArr = address.Split('/');
                    if (addressArr.Length>=2)
                    {
                        user.City = addressArr[2];
                        user.Country = addressArr[0];
                        user.ProvinceOrState = addressArr[1];
                    }
                    user.ImgUrl = "";//暂时空
                    user.Gender = sex;
//                    user.FirstName = firstname;
//                    user.LastName = lastname;
//                    user.NickName = nickname;
                    user.Remark = DateTime.Now.ToString();//修改日期
//                    user.Tab = tab;
                    user.WebUrl = weburl;
                    user.Email = email;
                    user.PhoneNumber = phone;
                    IdentityResult result = UserManager.Update(user);
                    if (result.Succeeded)
                    {
                        return Json(JsonHandler.CreateMessage(1, "更新成功"), JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(JsonHandler.CreateMessage(0, "更新失败：请稍后重试"), JsonRequestBehavior.AllowGet);
                    }
                    
                }
                else
                {
                    return Json(JsonHandler.CreateMessage(0, "更新失败：用户不存在，请重新登录" ), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return Json(JsonHandler.CreateMessage(-1, "更新失败："+e.Message), JsonRequestBehavior.AllowGet);
            }
        }

    }
}