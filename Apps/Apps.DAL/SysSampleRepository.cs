using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Apps.Models;
using Apps.IDAL;

namespace Apps.DAL
{
    public class SysSampleRepository : ISysSampleRepository
    {
        public IQueryable<syssample> GetList(DbContainer db)
        {
            return db.syssample.AsQueryable();
        }
        public int Create(syssample entity)
        {
            using (DbContainer db = new DbContainer())
            {
                db.syssample.Add(entity);
                return db.SaveChanges();
            }
        }
        public int Delete(int id)
        {
            using (DbContainer db = new DbContainer())
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    //改变实体状态，否则无法删除(报错)
                    db.Entry(entity).State = EntityState.Deleted;
                    db.Set<syssample>().Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public int Edit(syssample entity)
        {
            try
            {
                using (DbContainer db = new DbContainer())
                {
                    db.Set<syssample>().Attach(entity);
                    db.Entry(entity).State = EntityState.Modified;
                    return db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public syssample GetById(int id)
        {
            using (DbContainer db = new DbContainer())
            {
                return db.syssample.FirstOrDefault(u => u.ID == id);
            }
        }

        public bool IsExist(int id)
        {
            using (DbContainer db = new DbContainer())
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
