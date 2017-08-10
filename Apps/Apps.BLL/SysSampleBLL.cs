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
using Apps.Common;


namespace Apps.BLL
{
    public class SysSampleBLL : ISysSampleBLL
    {
        private DbContainer db = new DbContainer();
        //private ISysSampleRepository Rep = new SysSampleRepository();
        [Dependency]
        public ISysSampleRepository Rep { get; set; }
        public List<SysSampleModel> GetList(ref GridPager pager)
        {
            IQueryable<SysSample> queryData = null;
            queryData = Rep.GetList(db);

            if (pager.sort == "desc")
            {
                switch (pager.order)
                {
                    case "ID":
                        queryData = queryData.OrderByDescending(u => u.ID);
                        break;
                    case "Name":
                        queryData = queryData.OrderByDescending(u => u.Name);
                        break;
                    default:
                        queryData = queryData.OrderByDescending(u => u.CreateTime);
                        break;
                }
            }
            else
            {
                switch (pager.order)
                {
                    case "ID":
                        queryData = queryData.OrderBy(u => u.ID);
                        break;
                    case "Name":
                        queryData = queryData.OrderBy(u => u.Name);
                        break;
                    default:
                        queryData = queryData.OrderBy(u => u.CreateTime);
                        break;
                }
            }

            return CreateModelList(ref queryData, ref pager);
        }

        private List<SysSampleModel> CreateModelList(ref IQueryable<SysSample> queryData, ref GridPager pager)
        {
            pager.totalRows = queryData.Count();
            if (pager.totalRows > 0)
            {
                if (pager.page <= 1) pager.page = 1;

                queryData = queryData.Skip((pager.page - 1) * pager.rows).Take(pager.rows);

            }

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

                SysSample entity = Rep.GetById(model.ID);
                if (entity != null)
                {
                    return false;
                }
                entity = new SysSample();
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
                SysSample entity = Rep.GetById(model.ID);
                if (entity == null)
                {
                    return false;
                }
                entity = new SysSample();
                entity.ID = model.ID;
                entity.Name = model.Name;
                entity.Note = model.Note;
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
                SysSample entity = Rep.GetById(id);
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
