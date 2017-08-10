using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.Models;

namespace Apps.IDAL
{
    public interface ISysExceptionRepository
    {
        IQueryable<SysException> GetList( DbContainer db);
        SysException GetById(string id);
        bool Delete(string id);
        int Create(SysException entity);
    }
}
