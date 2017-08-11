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
using Apps.Core;
using Apps.Admin;

namespace Apps.Web.Controllers
{
    public class SysLogController : Controller
    {

        [Dependency]
        public ISysLogBLL SysLogBLL { get; set; }

        ValidationErrors errors = new ValidationErrors();

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
            if (SysLogBLL.Delete(ref errors, id))
            {
                LogHandler.WriteServiceLog(new SysLog { Operator = "虚拟用户", Message = "ID:" + id.ToString(), Result = "成功", Type = "删除", Module = "系统日志" });
                return Json(JsonHandler.CreateMessage(1, "删除成功"), JsonRequestBehavior.AllowGet);
            }
            else
            {
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog(new SysLog { Operator = "虚拟用户", Message = "ID:" + id.ToString(), Result = "失败", Type = "删除", Module = "系统日志" });
                return Json(JsonHandler.CreateMessage(0, "删除失败" + ErrorCol), JsonRequestBehavior.AllowGet);
            }
        }

    }
}