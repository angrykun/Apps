using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.IDAL;
using Apps.Models;

namespace Apps.DAL
{
    public class SysExceptionRepository : ISysExceptionRepository
    {
        public IQueryable<SysException> GetList(DbContainer db)
        {
            return db.SysException;
        }
        public SysException GetById(string id)
        {
            using (DbContainer db = new DbContainer())
            {
                return db.SysException.FirstOrDefault(u => u.ID == id);
            }
        }
        public bool Delete(string id)
        {
            using (DbContainer db = new DbContainer())
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                    db.SysException.Remove(entity);
                    return db.SaveChanges() > 0;
                }
                return false;
            }
        }

        public int Create(SysException entity)
        {
            using (DbContainer db = new DbContainer())
            {
                db.SysException.Add(entity);
                return db.SaveChanges();
            }
        }
    }
}
