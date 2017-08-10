using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apps.BLL;
using Apps.IBLL;
using Apps.Models;
using Microsoft.Practices.Unity;

namespace Apps.Web.Controllers
{
    public class HomeController : Controller
    {
        [Dependency]
        public IHomeBLL homeBLL { get; set; }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetTree(string id)
        {
            var menus = homeBLL.GetMenuByPersonId(id);
            var jsonData = (from m in menus
                            select new
                            {
                                id = m.ID,
                                text = m.Name,
                                value = m.Url,
                                showcheck = false,
                                complete = false,
                                isexpand = false,
                                checkstate = 0,
                                hasChildren = (bool)m.IsLast ? false : true,
                                Icon = m.Iconic
                            });
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}