using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPTS_API.Controllers
{
    public class SendMailController : Controller
    {
        string connection = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        // GET: SendMail
        public ActionResult SendMail()
        {
            List<FPTS_API.Models.SendMail> emails = FPTS_API.Controllers.SendMailAPIController.GetEmail(connection);
            return View(emails);
        }
    }
}