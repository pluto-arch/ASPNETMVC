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
    * [SysLog](
      [Id] [varchar](50) NOT NULL, --GUID
      [Operator] [varchar](50) NULL,--操作人
      [Message] [varchar](500) NULL,--操作信息
      [Result] [varchar](20) NULL,--结果
      [Type] [varchar](20) NULL,--操作类型
      [Module] [varchar](20) NULL,--操作模块
      [CreateTime] [datetime] NULL,--操作事件
    */
    public class SysLogsMap : EntityTypeConfiguration<SysLogs>
    {
        public SysLogsMap()
        {
            this.ToTable("SysLog");
            this.HasKey(l => l.Id);
            this.Property(u => u.Operator).HasMaxLength(60).IsRequired();
            this.Property(l => l.Module).HasMaxLength(30).IsRequired();
            this.Property(l => l.Result).HasMaxLength(30).IsRequired();
            this.Property(l => l.Type).HasMaxLength(20).IsRequired();
            this.Property(l => l.Message).HasMaxLength(500).IsRequired();
        }
    }
}
