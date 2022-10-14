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

        [HttpPost]
        public ActionResult SearchMail(string invoicecode, string fullname, string customeraddress, string email, string productname, string quantity, string price)
        {
            List<FPTS_API.Models.SendMail> emails = new List<FPTS_API.Models.SendMail>();
            emails = FPTS_API.Controllers.SendMailAPIController.SearchSendMail(connection,invoicecode, fullname, customeraddress, email, productname, quantity, price);
            return View(emails);
        }
    }
}