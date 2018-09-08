using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Models;

namespace Blog.Domain.Maps
{
    /// <summary>
    /// 实体的映射
    /// </summary>
    public class SysUserInfoMap: EntityTypeConfiguration<SysUserInfo>
    {
        public SysUserInfoMap()
        {
            this.HasKey(u => u.UId);//设置主键
            this.Property(u => u.ULoginName).HasMaxLength(60).IsRequired();//登录名最长60,必须
            this.Property(u => u.ULoginPwd).HasMaxLength(100).IsRequired();
            this.Property(u => u.URealName).HasMaxLength(100).IsRequired();
        }
    }
}
