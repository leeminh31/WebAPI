﻿using FPTS_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;

namespace FPTS_API.Controllers
{
    public class SendMailAPIController : ApiController
    {
        string connection = System.Configuration.ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

        //Lấy Dữ Liệu Send Mail
        [HttpGet]
        public List<SendMail> GetEmail ()
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
    }
}
