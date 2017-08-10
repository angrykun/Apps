using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.Models;
using Apps.Common;
using Apps.IBLL;
using Apps.IDAL;
using Microsoft.Practices.Unity;

namespace Apps.BLL
{
    public class SysLogBLL : ISysLogBLL
    {
        [Dependency]
        public ISysLogRepository SysLogRepository { get; set; }
        public List<SysLog> GetList(ref GridPager pager, string queryStr)
        {
            List<SysLog> query = null;
            IQueryable<SysLog> list = SysLogRepository.GetList(new DbContainer());

            if (!String.IsNullOrEmpty(queryStr))
            {
                list = list.Where(m => m.Message.Contains(queryStr) || m.Module.Contains(queryStr));
                pager.totalRows = list.Count();
            }
            else
            {
                pager.totalRows = list.Count();
            }
            if (pager.order == "desc")
            {
                query = list.OrderByDescending(c => c.CreateTime).Skip((pager.page - 1) * pager.rows).Take(pager.rows).ToList();
            }
            else
            {
                query = list.OrderBy(c => c.CreateTime).Skip((pager.page - 1) * pager.rows).Take(pager.rows).ToList();
            }
            return query;
        }
        public SysLog GetById(string id)
        {
            return SysLogRepository.GetById(id);
        }

        public bool Delete(string id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                string[] collection = new string[1];
                collection[0] = id;
                SysLogRepository.Delete(new DbContainer(), collection);
                return true;
            }
            return false;
        }
    }
}
