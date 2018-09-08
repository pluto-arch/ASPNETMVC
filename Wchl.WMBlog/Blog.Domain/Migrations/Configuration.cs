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
                    Message = "���������������˼�빤����ʹ�����񣬱�������ʱ���й���ɫ�������˼��͵���ʮ�Ŵ���Ϊָ������ǿ���ĸ���ʶ�����ᶨ���ĸ����š����Ծ��е�������ġ������ġ������ˡ����Ļ���չ�����ʹ�����񣬼����ȷ���η����ڻ����ԡ�ս���Թ������¹����ڹؼ�����Ҫ�����¹����ڹ���������ˮƽ���¹����ƶ�����˼�빤������ǿ�������ٽ�ȫ�����������������ֵ������¹����Ͻ����Ž���һ��Ϊ���񵳺͹�����ҵȫ�����������ס�",
                    Source = "�ٶ�",
                    StackTrace = "ERROR:����ķ�α���ֶΡ�__RequestVerificationToken��������"
                },
                new SysExceptions
                {
                    CreateTime = DateTime.Now,
                    Data = "aaaaa.dll",
                    HelpLink = "Http://www.baidu.com",
                    Id = 1,
                    Message = "���������������˼�빤����ʹ�����񣬱�������ʱ���й���ɫ�������˼��͵���ʮ�Ŵ���Ϊָ������ǿ���ĸ���ʶ�����ᶨ���ĸ����š����Ծ��е�������ġ������ġ������ˡ����Ļ���չ�����ʹ�����񣬼����ȷ���η����ڻ����ԡ�ս���Թ������¹����ڹؼ�����Ҫ�����¹����ڹ���������ˮƽ���¹����ƶ�����˼�빤������ǿ�������ٽ�ȫ�����������������ֵ������¹����Ͻ����Ž���һ��Ϊ���񵳺͹�����ҵȫ�����������ס�",
                    Source = "�ٶ�",
                    StackTrace = "ERROR:����ķ�α���ֶΡ�__RequestVerificationToken��������"
                },
                new SysExceptions
                {
                    CreateTime = DateTime.Now,
                    Data = "aaaaa.dll",
                    HelpLink = "Http://www.baidu.com",
                    Id = 2,
                    Message = "���������������˼�빤����ʹ�����񣬱�������ʱ���й���ɫ�������˼��͵���ʮ�Ŵ���Ϊָ������ǿ���ĸ���ʶ�����ᶨ���ĸ����š����Ծ��е�������ġ������ġ������ˡ����Ļ���չ�����ʹ�����񣬼����ȷ���η����ڻ����ԡ�ս���Թ������¹����ڹؼ�����Ҫ�����¹����ڹ���������ˮƽ���¹����ƶ�����˼�빤������ǿ�������ٽ�ȫ�����������������ֵ������¹����Ͻ����Ž���һ��Ϊ���񵳺͹�����ҵȫ�����������ס�",
                    Source = "�ٶ�",
                    StackTrace = "ERROR:����ķ�α���ֶΡ�__RequestVerificationToken��������"
                },
                new SysExceptions
                {
                    CreateTime = DateTime.Now,
                    Data = "aaaaa.dll",
                    HelpLink = "Http://www.baidu.com",
                    Id = 3,
                    Message = "���������������˼�빤����ʹ�����񣬱�������ʱ���й���ɫ�������˼��͵���ʮ�Ŵ���Ϊָ������ǿ���ĸ���ʶ�����ᶨ���ĸ����š����Ծ��е�������ġ������ġ������ˡ����Ļ���չ�����ʹ�����񣬼����ȷ���η����ڻ����ԡ�ս���Թ������¹����ڹؼ�����Ҫ�����¹����ڹ���������ˮƽ���¹����ƶ�����˼�빤������ǿ�������ٽ�ȫ�����������������ֵ������¹����Ͻ����Ž���һ��Ϊ���񵳺͹�����ҵȫ�����������ס�",
                    Source = "�ٶ�",
                    StackTrace = "ERROR:����ķ�α���ֶΡ�__RequestVerificationToken��������"
                }
            );
        }
    }
}
