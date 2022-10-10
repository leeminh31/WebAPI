using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPTS_API.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult Invoice()
        {
            return View();
        }

        public ActionResult InvoiceLine()
        {
            return View();
        }

        public ActionResult InvoiceSetup()
        {
            return View();
        }
    }
}