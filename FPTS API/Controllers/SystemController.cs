using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPTS_API.Controllers
{
    public class SystemController : Controller
    {
        // GET: System
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Customer()
        {
            return View();
        }

        public ActionResult Supplier()
        {
            return View();
        }

        public ActionResult UserGroup()
        {
            return View();
        }
    }
}