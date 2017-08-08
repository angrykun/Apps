using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Common
{
    public class GridPager
    {
        public int rows { get; set; }
        public int page { get; set; }
        public string order { get; set; }
        public string sort { get; set; }
        public int totalRows { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int totalPages
        {
            get
            {
                return (int)Math.Ceiling((float)totalRows / rows);
            }
        }
    }
}
