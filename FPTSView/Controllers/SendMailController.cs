using FPTS_API.Models;
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
        public ActionResult SendMail(string invoicecode, string fullname, string customeraddress, string email, string productname, string quantity, string price)
        {
            List<FPTS_API.Models.SendMail> emails = FPTS_API.Controllers.SendMailAPIController.SearchSendMail(connection, invoicecode, fullname, customeraddress, email, productname, quantity, price);
            return View(emails);
        }

        [HttpPost]
        public ActionResult SendMailForCheckList (List<FPTS_API.Models.SendMail> list)
        {
            string email = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
            string password = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();
            List<string> Emails = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IsChecked)
                {
                    Emails.Add(Request["emailvalue" + i]);
                }
            }
            FPTS_API.Controllers.SendMailAPIController.SendMail(Emails, "Test SMTP Email", "<p>There is nothing to focus here !</p>", email, password);
            return Redirect(Url.Action("SendMail", "SendMail"));
        }
    }
}