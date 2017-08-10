using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apps.BLL;
using Apps.Models.Sys;
using Apps.IBLL;
using Microsoft.Practices.Unity;
using Apps.Common;

namespace Apps.Web.Controllers
{
    public class SysExceptionController : Controller
    {
        [Dependency]
        public ISysExceptionBLL SysExceptionBLL { get; set; }
        // GET: SysException
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetList(GridPager pager, string queryStr)
        {
            var list = SysExceptionBLL.GetList(ref pager, queryStr);
            var dataJson = new
            {
                total = pager.totalRows,
                rows = (from m in list
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
                        }).ToArray()
            };
            return Json(dataJson, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Details(string id)
        {
            var entity = SysExceptionBLL.GetById(id);
            return View(entity);
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            if (SysExceptionBLL.Delete(id))
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