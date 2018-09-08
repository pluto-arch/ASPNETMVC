using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Models
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
    /// <summary>
    /// 系统异常
    /// </summary>
    public class SysExceptions
    {
        public int Id { get; set; }
        public string HelpLink { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
        public string TargetSite { get; set; }
        public string Data { get; set; }
        public DateTime CreateTime { get; set; }

    }
}
