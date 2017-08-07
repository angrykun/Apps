using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.Models;

namespace Apps.IDAL
{
    public interface ISysSampleRepository
    {
        IQueryable<syssample> GetList(DbContainer db);
        int Create(syssample entity);
        int Delete(int id);
        int Edit(syssample entity);
        syssample GetById(int id);
        bool IsExist(int id);

    }
}
