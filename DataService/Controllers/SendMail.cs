using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DataService.Controllers
{
    public class SendMail
    {
        public static DataTable Search(string connectionString, string invoicecode, string fullname, string customeraddress, string email, string productname, string quantity, string price)
        {
            string query = String.Format("select * from send_email where InvoiceCode = '{0}'", invoicecode);
            if (!String.IsNullOrEmpty(fullname))
            {
                query += String.Format(" and Fullname LIKE N'%{0}%'", fullname);
            }
            if (!String.IsNullOrEmpty(customeraddress))
            {
                query += String.Format(" and CustomerAddress LIKE N'%{0}%'", customeraddress);
            }
            if (!String.IsNullOrEmpty(email))
            {
                query += String.Format(" and Email LIKE '%{0}%'", email);
            }
            if (!String.IsNullOrEmpty(productname))
            {
                query += String.Format(" and ProductName LIKE N'%{0}%'", productname);
            }
            if (!String.IsNullOrEmpty(quantity))
            {
                query += String.Format(" and Quantity = {0}", quantity);
            }
            if (!String.IsNullOrEmpty(price))
            {
                query += String.Format(" and Price = {0}", price);
            }
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            dataAdapter.Fill(dt);
            return dt;
        }

        public static bool SendMailList(List<string> toEmail, string subject, string body, string email, string password)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.Timeout = 100000;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(email, password);

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(email);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                mail.BodyEncoding = UTF8Encoding.UTF8;

                foreach (string s in toEmail)
                {
                    mail.To.Add(new MailAddress(s));
                }
                smtpClient.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static DataTable  GetAll(string connectionString)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("sp_select_send_mail", cnn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable tbl = new DataTable();
            da.Fill(tbl);
            return tbl;
        }
    }
}