using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Models
{
    /// <summary>
    /// 系统日志类
    /// </summary>
    public class SysLogs
    {
        public int Id { get; set; }
        public string Operator { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public string Type { get; set; }
        public string Module { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
