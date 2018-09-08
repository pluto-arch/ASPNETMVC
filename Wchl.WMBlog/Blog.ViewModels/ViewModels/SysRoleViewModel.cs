using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ViewModels.ViewModels
{
    public class SysRoleViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreateTime { get; set; }
        public string ParentId { get; set; }
        public bool? State { get; set; }
        public string UserNames { get; set; }
        public string Remark { get; set; }
    }
}
