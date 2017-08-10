using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.Models;


namespace Apps.IDAL
{
    public interface ISysLogRepository
    {
        int Create(SysLog entity);
        void Delete(DbContainer db, string[] deleteCollection);
        IQueryable<SysLog> GetList(DbContainer db);
        SysLog GetById(string id);
    }
}
