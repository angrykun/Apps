using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apps.BLL;
using Apps.IBLL;
using Apps.Models;
using Microsoft.Practices.Unity;
using Apps.Models.Sys;
using Apps.Common;
using Apps.Admin;

namespace Apps.Web.Controllers
{
    public class SysSampleController : BaseController
    {
        //private ISysSampleBLL bll = new SysSampleBLL();
        /// <summary>
        /// 业务层注入
        /// </summary>
        [Dependency]
        public ISysSampleBLL m_BLL { get; set; }

        ValidationErrors errors = new ValidationErrors();
        // GET: SysSample
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetList(GridPager pager)
        {
            var list = m_BLL.GetList(ref pager);

            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new SysSampleModel
                        {
                            ID = (int)r.ID,
                            Name = r.Name,
                            Bir = r.Bir,
                            Age = r.Age,
                            CreateTime = r.CreateTime,
                            Note = r.Note,
                            Photo = r.Photo
                        })
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        #region Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(true)]
        public ActionResult Create(SysSampleModel model)
        {
            if (m_BLL.Create(ref errors, model))
            {
                LogHandler.WriteServiceLog(new SysLog { Operator = "虚拟用户", Message = "ID:" + model.ID.ToString() + ",Name:" + model.Name, Result = "成功", Type = "创建", Module = "样例程序" });
                return Json(JsonHandler.CreateMessage(1, "插入成功"), JsonRequestBehavior.AllowGet);
            }
            else
            {
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog(new SysLog { Operator = "虚拟用户", Message = "ID:" + model.ID.ToString() + ",Name:" + model.Name, Result = "失败", Type = "创建", Module = "样例程序" });
                return Json(JsonHandler.CreateMessage(0, "插入失败" + ErrorCol), JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        public ActionResult Details(int id)
        {
            var entity = m_BLL.GetById(id);
            return View(entity);
        }

        #region Edit
        public ActionResult Edit(int id)
        {
            var entity = m_BLL.GetById(id);

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SysSampleModel model)
        {
            if (m_BLL.Edit(ref errors, model))
            {
                LogHandler.WriteServiceLog(new SysLog { Operator = "虚拟用户", Message = "ID:" + model.ID.ToString() + ",Name:" + model.Name, Result = "成功", Type = "修改", Module = "样例程序" });
                return Json(JsonHandler.CreateMessage(1, "修改成功"), JsonRequestBehavior.AllowGet);
            }
            else
            {
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog(new SysLog { Operator = "虚拟用户", Message = "ID:" + model.ID.ToString() + ",Name:" + model.Name, Result = "失败", Type = "修改", Module = "样例程序" });
                return Json(JsonHandler.CreateMessage(0, "修改失败" + ErrorCol), JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (m_BLL.Delete(ref errors, id))
            {
                LogHandler.WriteServiceLog(new SysLog { Operator = "虚拟用户", Message = "ID:" + id.ToString(), Result = "成功", Type = "删除", Module = "样例程序" });
                return Json(JsonHandler.CreateMessage(1, "删除成功"), JsonRequestBehavior.AllowGet);
            }
            else
            {
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog(new SysLog { Operator = "虚拟用户", Message = "ID:" + id.ToString(), Result = "失败", Type = "删除", Module = "样例程序" });
                return Json(JsonHandler.CreateMessage(0, "删除失败" + ErrorCol), JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

    }
}