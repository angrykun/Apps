using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.Models;
using Apps.Models.Sys;

namespace Apps.IBLL
{
    public interface ISysSampleBLL
    {
        List<SysSampleModel> GetList(string queryStr);
        bool Create(SysSampleModel entity);
        bool Delete(int id);
        bool Edit(SysSampleModel entity);
        SysSampleModel GetById(int id);
        bool IsExist(int id);
    }
}
