using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.IDAL;
using Apps.Models;

namespace Apps.DAL
{
    /// <summary>
    /// 操作日志DAL
    /// </summary>
    public class SysLogRepository : ISysLogRepository
    {
        public int Create(SysLog entity)
        {
            using (DbContainer db = new DbContainer())
            {
                db.SysLog.Add(entity);
                return db.SaveChanges();
            }
        }
        public void Delete(DbContainer db, string[] deleteCollection)
        {
            var collection = (from f in db.SysLog
                              where deleteCollection.Contains(f.ID)
                              select f).ToList();
            collection.ForEach(item =>
            {
                db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                db.SysLog.Remove(item);
            });
        }

        public SysLog GetById(string id)
        {
            using (DbContainer db = new DbContainer())
            {
                return db.SysLog.SingleOrDefault(u => u.ID == id);
            }
        }
        public IQueryable<SysLog> GetList(DbContainer db)
        {
            return db.SysLog;
        }
    }
}
