using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.Models;
using Apps.Models.Sys;
using Apps.Common;

namespace Apps.IBLL
{
    public interface ISysSampleBLL
    {
        List<SysSampleModel> GetList(ref GridPager pager);
        bool Create(ref ValidationErrors errors, SysSampleModel entity);
        bool Delete(ref ValidationErrors errors, int id);
        bool Edit(ref ValidationErrors errors, SysSampleModel entity);
        SysSampleModel GetById( int id);
        bool IsExist(int id);
    }
}
