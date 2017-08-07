using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apps.BLL;
using Apps.IBLL;
using Apps.Models;

namespace Apps.Web.Controllers
{
    public class SysSampleController : Controller
    {
        private ISysSampleBLL bll = new SysSampleBLL();

        // GET: SysSample
        public ActionResult Index()
        {
            var data = bll.GetList("");
            return View(data);
        }
    }
}