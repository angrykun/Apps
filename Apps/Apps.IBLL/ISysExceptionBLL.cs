using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.Models.Sys;
using Apps.Common;

namespace Apps.IBLL
{
    public interface ISysExceptionBLL
    {
        List<SysExceptionModel> GetList(ref GridPager pager, string queryStr);
        SysExceptionModel GetById(string id);
        bool Delete(string id);
    }
}
