using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.IDAL;
using Apps.Models;

namespace Apps.DAL
{
    public class HomeRepository : IHomeRepository
    {

        public List<SysModule> GetMenuByPersonId(string moduleId)
        {
            using (DbContainer db = new DbContainer())
            {
                var menus = (from m in db.SysModule
                             where m.ParentID == moduleId
                             where m.ID != "0"
                             select m).Distinct().OrderBy(u => u.Sort).ToList();
                return menus;
            }
        }
    }
}
