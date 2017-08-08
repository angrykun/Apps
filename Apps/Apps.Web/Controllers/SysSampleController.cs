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

namespace Apps.Web.Controllers
{
    public class SysSampleController : Controller
    {
        //private ISysSampleBLL bll = new SysSampleBLL();
        /// <summary>
        /// 业务层注入
        /// </summary>
        [Dependency]
        public ISysSampleBLL m_BLL { get; set; }

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
    }
}