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
    public class SysSampleController : Controller
    {
        //private ISysSampleBLL bll = new SysSampleBLL();
        [Dependency]
        public ISysSampleBLL m_BLL { get; set; }

        // GET: SysSample
        public ActionResult Index()
        {
            var data = m_BLL.GetList("");
            return View(data);
        }
    }
}