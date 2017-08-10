using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apps.Common;
using Apps.Models;
using Microsoft.Practices.Unity;
using Apps.IBLL;
using Apps.Models.Sys;

namespace Apps.Web.Controllers
{
    public class SysLogController : Controller
    {

        [Dependency]
        public ISysLogBLL SysLogBLL { get; set; }
        // GET: SysLog
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetList(GridPager pager, string queryStr)
        {
            List<SysLog> list = SysLogBLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new SysLogModel()
                        {
                            ID = r.ID,
                            Operator = r.Operator,
                            Message = r.Message,
                            Result = r.Result,
                            Type = r.Type,
                            Module = r.Module,
                            CreateTime = r.CreateTime

                        }).ToArray()

            };

            return Json(json);
        }


        #region 详细   
        public ActionResult Details(string id)
        {

            SysLog entity = SysLogBLL.GetById(id);
            SysLogModel info = new SysLogModel()
            {
                ID = entity.ID,
                Operator = entity.Operator,
                Message = entity.Message,
                Result = entity.Result,
                Type = entity.Type,
                Module = entity.Module,
                CreateTime = entity.CreateTime,
            };
            return View(info);
        }

        #endregion

        [HttpPost]
        public JsonResult Delete(string id)
        {
            if (SysLogBLL.Delete(id))
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }

    }
}