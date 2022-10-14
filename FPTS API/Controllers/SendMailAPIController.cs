using FPTS_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FPTS_API.Controllers
{
    public class SendMailAPIController : ApiController
    {
        //Lấy Dữ Liệu Send Mail
        [HttpGet]
        public static List<SendMail> GetEmail (string connection)
        {
            DataTable table = DataService.Controllers.SendMail.GetAll(connection);
            List<SendMail> list = new List<SendMail>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                SendMail mail = new SendMail();
                mail.Quantity = Convert.ToInt32(table.Rows[i]["Quantity"].ToString());
                mail.Price = Convert.ToInt32(table.Rows[i]["Price"].ToString());
                mail.InvoiceCode = table.Rows[i]["InvoiceCode"].ToString();
                mail.Fullname = table.Rows[i]["Fullname"].ToString();
                mail.CustomerAddress = table.Rows[i]["CustomerAddress"].ToString();
                mail.Email = table.Rows[i]["Email"].ToString();
                mail.ProductName = table.Rows[i]["ProductName"].ToString();
                list.Add(mail);
            }
            return list;
        }

        public static List<SendMail> SearchSendMail(string connection, string invoicecode, string fullname, string customeraddress, string email, string productname, string quantity, string price)
        {
            List<SendMail> list = new List<SendMail>();
            DataTable table = DataService.Controllers.SendMail.Search(connection, invoicecode, fullname, customeraddress, email, productname, quantity, price);
            foreach(DataRow dr in table.Rows)
            {
                SendMail mail = new SendMail();
                mail.InvoiceCode = dr["InvoiceCode"].ToString();
                mail.Email = dr["Email"].ToString();
                mail.Quantity = Convert.ToInt32(dr["Quantity"].ToString());
                mail.Price = Convert.ToInt32(dr["Price"].ToString());
                mail.CustomerAddress = dr["CustomerAddress"].ToString();
                mail.Fullname = dr["Fullname"].ToString();
                mail.ProductName = dr["ProductName"].ToString();
                mail.IsChecked = false;
                list.Add(mail);
            } 
            return list;
        }

        public static void SendMail (List<string> toEmails, string subject, string body, string email, string password)
        {
            bool result = DataService.Controllers.SendMail.SendMailList(toEmails, subject, body, email, password);
        }
    }
}
