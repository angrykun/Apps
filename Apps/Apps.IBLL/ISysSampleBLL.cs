using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.Models;

namespace Apps.IBLL
{
    public interface ISysSampleBLL
    {
        IQueryable<syssample> GetList(string queryStr);
        bool Create(syssample entity);
        bool Delete(int id);
        bool Edit(syssample entity);
        syssample GetById(int id);
        bool IsExist(int id);
    }
}
