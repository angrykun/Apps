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
        IQueryable<SysSample> GetList(DbContainer db);
        int Create(SysSample entity);
        int Delete(int id);
        int Edit(SysSample entity);
        SysSample GetById(int id);
        bool IsExist(int id);

    }
}
