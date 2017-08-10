using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.IDAL;
using Apps.IBLL;
using Apps.Models;
using Apps.Models.Sys;
using Apps.Common;
using Microsoft.Practices.Unity;

namespace Apps.BLL
{
    public class SysExceptionBLL : ISysExceptionBLL
    {
        [Dependency]
        public ISysExceptionRepository SysExceptionRepository { get; set; }
        public List<SysExceptionModel> GetList(ref GridPager pager, string queryStr)
        {
            IQueryable<SysExceptionModel> list = from m in SysExceptionRepository.GetList(new DbContainer())
                                                 select new SysExceptionModel
                                                 {
                                                     ID = m.ID,
                                                     CreateTime = m.CreateTime,
                                                     Data = m.Data,
                                                     HelpLink = m.HelpLink,
                                                     Message = m.Message,
                                                     Source = m.Source,
                                                     StackTrace = m.StackTrace,
                                                     TargetSite = m.TargetSite
                                                 };
            if (!String.IsNullOrEmpty(queryStr))
            {
                list = list.Where(m => m.Message.Contains(queryStr));
            }
            pager.totalRows = list.Count();
            if (pager.order == "desc")
            {
                return list.OrderByDescending(c => c.CreateTime).Skip((pager.page - 1) * pager.rows).Take(pager.rows).ToList();
            }
            else
            {
                return list.OrderBy(c => c.CreateTime).Skip((pager.page - 1) * pager.rows).Take(pager.rows).ToList();
            }
        }
        public SysExceptionModel GetById(string id)
        {
            var entity = SysExceptionRepository.GetById(id);
            if (entity != null)
            {
                return new SysExceptionModel
                {
                    ID = entity.ID,
                    CreateTime = entity.CreateTime,
                    Data = entity.Data,
                    HelpLink = entity.HelpLink,
                    Message = entity.Message,
                    Source = entity.Source,
                    StackTrace = entity.StackTrace,
                    TargetSite = entity.TargetSite
                };
            }
            return null;
        }
        public bool Delete(string id)
        {
            var entity = SysExceptionRepository.GetById(id);
            if (entity != null)
            {
                return SysExceptionRepository.Delete(id);
            }
            return false;
        }  
    }
}
