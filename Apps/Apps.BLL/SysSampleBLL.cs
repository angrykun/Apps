using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.DAL;
using Apps.IDAL;
using Apps.Models;
using Apps.Models.Sys;
using Apps.IBLL;
using Microsoft.Practices.Unity;

namespace Apps.BLL
{
    public class SysSampleBLL : ISysSampleBLL
    {
        private DbContainer db = new DbContainer();
        //private ISysSampleRepository Rep = new SysSampleRepository();
        [Dependency]
        public ISysSampleRepository Rep { get; set; }
        public List<SysSampleModel> GetList(string queryStr)
        {
            IQueryable<syssample> queryData = null;
            queryData = Rep.GetList(db);
            return CreateModelList(ref queryData);
        }

        private List<SysSampleModel> CreateModelList(ref IQueryable<syssample> queryData)
        {
            List<SysSampleModel> modelList = (from r in queryData
                                              select new SysSampleModel
                                              {
                                                  ID = (int)r.ID,
                                                  Name = r.Name,
                                                  Bir = r.Bir,
                                                  Age = r.Age,
                                                  CreateTime = r.CreateTime,
                                                  Note = r.Note,
                                                  Photo = r.Photo
                                              }).ToList();
            return modelList;
        }

        public bool Create(SysSampleModel model)
        {
            try
            {

                syssample entity = Rep.GetById(model.ID);
                if (entity != null)
                {
                    return false;
                }
                entity = new syssample();
                entity.ID = model.ID;
                entity.Name = model.Name;
                entity.Note = model.Name;
                entity.Photo = model.Photo;
                entity.Bir = model.Bir;
                entity.Age = model.Age;
                entity.CreateTime = model.CreateTime;
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

        public bool Edit(SysSampleModel model)
        {
            try
            {
                syssample entity = Rep.GetById(model.ID);
                if (entity != null)
                {
                    return false;
                }
                entity = new syssample();
                entity.ID = model.ID;
                entity.Name = model.Name;
                entity.Note = model.Name;
                entity.Photo = model.Photo;
                entity.Bir = model.Bir;
                entity.Age = model.Age;
                entity.CreateTime = model.CreateTime;
                if (Rep.Edit(entity) > 0)
                { return true; }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public SysSampleModel GetById(int id)
        {
            if (IsExist(id))
            {
                syssample entity = Rep.GetById(id);
                SysSampleModel model = new SysSampleModel();
                model.ID = (int)entity.ID;
                model.Name = entity.Name;
                model.Age = entity.Age;
                model.Bir = entity.Bir;
                model.Photo = entity.Photo;
                model.Note = entity.Note;
                model.CreateTime = entity.CreateTime;
                return model;
            }
            return new SysSampleModel();
        }

        public bool IsExist(int id)
        {
            return Rep.IsExist(id);
        }

    }
}
