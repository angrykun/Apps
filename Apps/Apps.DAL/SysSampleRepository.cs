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
        public IQueryable<SysSample> GetList(DbContainer db)
        {
            return db.SysSample.AsQueryable();
        }
        public int Create(SysSample entity)
        {
            using (DbContainer db = new DbContainer())
            {
                db.SysSample.Add(entity);
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
                    db.Set<SysSample>().Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public int Edit(SysSample entity)
        {
            try
            {
                using (DbContainer db = new DbContainer())
                {
                    db.Set<SysSample>().Attach(entity);
                    db.Entry(entity).State = EntityState.Modified;
                    return db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public SysSample GetById(int id)
        {
            using (DbContainer db = new DbContainer())
            {
                return db.SysSample.FirstOrDefault(u => u.ID == id);
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
