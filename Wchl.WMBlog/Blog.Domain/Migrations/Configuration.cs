using Blog.Domain.Models;

namespace Blog.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Blog.Domain.BlogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Blog.Domain.BlogDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Set<SysUserInfo>().AddOrUpdate(
                new SysUserInfo { URealName = "jack", UCreateTime = DateTime.Now, ULoginName = "jack", ULoginPwd = "123456", UState = 1 },
                new SysUserInfo { URealName = "black", UCreateTime = DateTime.Now, ULoginName = "black", ULoginPwd = "123456", UState = 1 },
                new SysUserInfo { URealName = "delete", UCreateTime = DateTime.Now, ULoginName = "delete", ULoginPwd = "123456", UState = 1 },
                new SysUserInfo { URealName = "zhangsan", UCreateTime = DateTime.Now, ULoginName = "zhangsan", ULoginPwd = "123456", UState = 1 },
                new SysUserInfo { URealName = "wangwu", UCreateTime = DateTime.Now, ULoginName = "wangwu", ULoginPwd = "123456", UState = 1 },
                new SysUserInfo { URealName = "lisi", UCreateTime = DateTime.Now, ULoginName = "lisi", ULoginPwd = "123456", UState = 1 }
            );
            context.Set<SysLogs>().AddOrUpdate(
                new SysLogs
                {
                    CreateTime = DateTime.Now,
                    Id = 0,
                    Message = "Hello this is my blog, welcome to my world.",
                    Module = "/Adm/Default/Index",
                    Operator = "Admin",
                    Result = "File",
                    Type = "Create"
                },
                new SysLogs
                {
                    CreateTime = DateTime.Now,
                    Id = 1,
                    Message = "Hello this is my blog, welcome to my world.",
                    Module = "/Adm/Default/Index",
                    Operator = "zhangyulong",
                    Result = "Success",
                    Type = "Edit"
                },
                new SysLogs
                {
                    CreateTime = DateTime.Now,
                    Id = 2,
                    Message = "Hello this is my blog, welcome to my world.",
                    Module = "/Adm/Default/Index",
                    Operator = "zhangyulong",
                    Result = "File",
                    Type = "Create"
                },
                new SysLogs
                {
                    CreateTime = DateTime.Now,
                    Id = 3,
                    Message = "Hello this is my blog, welcome to my world.",
                    Module = "/Adm/Default/Index",
                    Operator = "zhangyulong",
                    Result = "Success",
                    Type = "Delete"
                },
                new SysLogs
                {
                    CreateTime = DateTime.Now,
                    Id = 4,
                    Message = "Hello this is my blog, welcome to my world.",
                    Module = "/Adm/Default/Index",
                    Operator = "Admin",
                    Result = "Success",
                    Type = "Delete"
                }
            );

            context.Set<SysExceptions>().AddOrUpdate(
                new SysExceptions
                {
                    CreateTime = DateTime.Now,
                    Data = "aaaaa.dll",
                    HelpLink = "Http://www.baidu.com",
                    Id = 0,
                    Message = "完成新形势下宣传思想工作的使命任务，必须以新时代中国特色社会主义思想和党的十九大精神为指导，增强‘四个意识’、坚定‘四个自信’，自觉承担起举旗帜、聚民心、育新人、兴文化、展形象的使命任务，坚持正确政治方向，在基础性、战略性工作上下功夫，在关键处、要害处下功夫，在工作质量和水平上下功夫，推动宣传思想工作不断强起来，促进全体人民在理想信念、价值理念、道德观念上紧紧团结在一起，为服务党和国家事业全局作出更大贡献。",
                    Source = "百度",
                    StackTrace = "ERROR:所需的防伪表单字段“__RequestVerificationToken”不存在"
                },
                new SysExceptions
                {
                    CreateTime = DateTime.Now,
                    Data = "aaaaa.dll",
                    HelpLink = "Http://www.baidu.com",
                    Id = 1,
                    Message = "完成新形势下宣传思想工作的使命任务，必须以新时代中国特色社会主义思想和党的十九大精神为指导，增强‘四个意识’、坚定‘四个自信’，自觉承担起举旗帜、聚民心、育新人、兴文化、展形象的使命任务，坚持正确政治方向，在基础性、战略性工作上下功夫，在关键处、要害处下功夫，在工作质量和水平上下功夫，推动宣传思想工作不断强起来，促进全体人民在理想信念、价值理念、道德观念上紧紧团结在一起，为服务党和国家事业全局作出更大贡献。",
                    Source = "百度",
                    StackTrace = "ERROR:所需的防伪表单字段“__RequestVerificationToken”不存在"
                },
                new SysExceptions
                {
                    CreateTime = DateTime.Now,
                    Data = "aaaaa.dll",
                    HelpLink = "Http://www.baidu.com",
                    Id = 2,
                    Message = "完成新形势下宣传思想工作的使命任务，必须以新时代中国特色社会主义思想和党的十九大精神为指导，增强‘四个意识’、坚定‘四个自信’，自觉承担起举旗帜、聚民心、育新人、兴文化、展形象的使命任务，坚持正确政治方向，在基础性、战略性工作上下功夫，在关键处、要害处下功夫，在工作质量和水平上下功夫，推动宣传思想工作不断强起来，促进全体人民在理想信念、价值理念、道德观念上紧紧团结在一起，为服务党和国家事业全局作出更大贡献。",
                    Source = "百度",
                    StackTrace = "ERROR:所需的防伪表单字段“__RequestVerificationToken”不存在"
                },
                new SysExceptions
                {
                    CreateTime = DateTime.Now,
                    Data = "aaaaa.dll",
                    HelpLink = "Http://www.baidu.com",
                    Id = 3,
                    Message = "完成新形势下宣传思想工作的使命任务，必须以新时代中国特色社会主义思想和党的十九大精神为指导，增强‘四个意识’、坚定‘四个自信’，自觉承担起举旗帜、聚民心、育新人、兴文化、展形象的使命任务，坚持正确政治方向，在基础性、战略性工作上下功夫，在关键处、要害处下功夫，在工作质量和水平上下功夫，推动宣传思想工作不断强起来，促进全体人民在理想信念、价值理念、道德观念上紧紧团结在一起，为服务党和国家事业全局作出更大贡献。",
                    Source = "百度",
                    StackTrace = "ERROR:所需的防伪表单字段“__RequestVerificationToken”不存在"
                }
            );
        }
    }
}
