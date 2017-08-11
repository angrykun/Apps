using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.Models;
using Apps.Common;

namespace Apps.IBLL
{
    public interface ISysLogBLL
    {
        List<SysLog> GetList(ref GridPager pager, string queryStr);
        SysLog GetById(string id);

        bool Delete(ref ValidationErrors errors, string id);
    }
}
