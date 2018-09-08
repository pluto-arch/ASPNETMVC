using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Common
{
    /// <summary>
    /// 分页
    /// </summary>
    public class GridPager
    {
        public int rows { get; set; }//每页行数
        public int page { get; set; }//当前页是第几页
        public string order { get; set; }//排序方式
        public int totalRows { get; set; }//总行数
    }
}
