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
using Apps.Admin;
using Apps.Models;

namespace Apps.Web.Controllers
{
    public class SysExceptionController : Controller
    {
        [Dependency]
        public ISysExceptionBLL SysExceptionBLL { get; set; }

        ValidationErrors errors = new ValidationErrors();
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
            if (SysExceptionBLL.Delete(ref errors ,id))
            {
                LogHandler.WriteServiceLog(new SysLog { Operator = "虚拟用户", Message = "ID:" + id.ToString(), Result = "成功", Type = "删除", Module = "系统异常" });
                return Json(JsonHandler.CreateMessage(1, "删除成功"), JsonRequestBehavior.AllowGet);
            }
            else
            {
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog(new SysLog { Operator = "虚拟用户", Message = "ID:" + id.ToString(), Result = "失败", Type = "删除", Module = "系统异常" });
                return Json(JsonHandler.CreateMessage(0, "删除失败" + ErrorCol), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 错误页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Error()
        {
            BaseException exception = new BaseException();
            return View(exception);
        }
    }
}