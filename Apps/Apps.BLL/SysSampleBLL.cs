using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.DAL;
using Apps.IDAL;
using Apps.Models;
using Apps.IBLL;

namespace Apps.BLL
{
    public class SysSampleBLL : ISysSampleBLL
    {
        private DbContainer db = new DbContainer();
        private ISysSampleRepository Rep = new SysSampleRepository();
        public IQueryable<syssample> GetList(string queryStr)
        {
            IQueryable<syssample> queryData = Rep.GetList(db);
            return queryData;
        }

        public bool Create(syssample entity)
        {
            try
            {
                if (Rep.Create(entity) == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                if (Rep.Delete(id) > 0)
                {
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(syssample entity)
        {
            try
            {
                if (Rep.Edit(entity) > 0)
                { return true; }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public syssample GetById(int id)
        {
            if (IsExist(id))
            {
                return Rep.GetById(id);
            }
            return null;
        }

        public bool IsExist(int id)
        {
            return Rep.IsExist(id);
        }

    }
}
