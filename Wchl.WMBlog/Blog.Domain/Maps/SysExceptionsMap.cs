using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Models;

namespace Blog.Domain.Maps
{
    /*
    [Id] [varchar](50) NOT NULL, --GUID
    [HelpLink][varchar] (500) NULL,--帮助链接
    [Message][varchar] (500) NULL,--异常信息
    [Source][varchar] (500) NULL,--来源
    [StackTrace][text] NULL,--堆栈
    [TargetSite][varchar] (500) NULL,--目标页
    [Data][varchar] (500) NULL,--程序集
    [CreateTime][datetime] NULL,--发生时间*/
    public class SysExceptionsMap: EntityTypeConfiguration<SysExceptions>
    {
        public SysExceptionsMap()
        {
            this.ToTable("SysException");
            this.HasKey(e => e.Id);
            this.Property(e => e.HelpLink).HasMaxLength(500);
            this.Property(e => e.Message).HasMaxLength(500);
            this.Property(e => e.Source).HasMaxLength(500);
            this.Property(e => e.StackTrace).HasColumnType("text");
            this.Property(e => e.TargetSite).HasMaxLength(500);
            this.Property(e => e.Data).HasMaxLength(500);
        }
    }
}
