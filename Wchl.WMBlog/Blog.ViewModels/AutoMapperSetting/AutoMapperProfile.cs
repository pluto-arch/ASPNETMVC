using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Domain.Models;

namespace Blog.ViewModels.AutoMapperSetting
{
    /// <summary>
    /// AutoMapper的设置
    /// </summary>
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SysUserInfo, SysUserInfoViewModel>().ForMember(a=>a.Id, opt =>
            {
                opt.MapFrom(s=>s.UId);
            });
            CreateMap<SysUserInfoViewModel, SysUserInfo>().ForMember(o=>o.UId, opt =>
            {
                opt.MapFrom(a=>a.Id);
            });

            CreateMap<SysLogs, SysLogViewModel>().ForMember(a => a.Id, opt =>
            {
                opt.MapFrom(s => s.Id);
            });
            CreateMap<SysLogViewModel, SysLogs>().ForMember(o => o.Id, opt =>
            {
                opt.MapFrom(a => a.Id);
            });


            CreateMap<SysExceptions, SysExceptionViewModel>().ForMember(a => a.Id, opt =>
            {
                opt.MapFrom(s => s.Id);
            });
            CreateMap<SysExceptionViewModel, SysExceptions>().ForMember(o => o.Id, opt =>
            {
                opt.MapFrom(a => a.Id);
            });

        }
    }
}
