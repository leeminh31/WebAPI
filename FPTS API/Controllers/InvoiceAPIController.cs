using FPTS_API.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;

namespace FPTS_API.Controllers
{
    public class InvoiceAPIController : ApiController
    {
        // Lấy Dữ Liệu Invoice
        [HttpGet]
        public static List<Invoice> GetInvoice(string connection)
        {
            DataTable table = DataService.Controllers.Invoice.GetAll(connection);
            List<Invoice> list = new List<Invoice>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Invoice invoice = new Invoice();
                invoice.InvoiceId = Convert.ToInt32(table.Rows[i]["InvoiceID"].ToString());
                invoice.CustomerId = Convert.ToInt32(table.Rows[i]["CustomerID"].ToString());
                invoice.SupplierId = Convert.ToInt32(table.Rows[i]["SupplierID"].ToString());
                invoice.InvoiceSetupId = Convert.ToInt32(table.Rows[i]["InvoiceSetupID"].ToString());
                invoice.InvoiceCode = table.Rows[i]["InvoiceCode"].ToString();
                invoice.StartDate = Convert.ToDateTime(table.Rows[i]["StartDate"].ToString());
                list.Add(invoice);
            }
            return list;
        }

        public static void CreateInvoice(string connection,string create, string invoiceid, string customerid, string invoicesetupid, string supplierid, string startdate)
        {
            if (create == "Create")
            {
                DataService.Controllers.Invoice.Create(connection, invoiceid, customerid, supplierid, invoicesetupid, startdate);
            }
        }

        public static void UpdateInvoice(string connection,string update, string invoiceid, string customerid, string invoicesetupid, string supplierid, string startdate)
        {
            if (update == "Update")
            {
                DataService.Controllers.Invoice.Update(connection, customerid, supplierid, invoiceid, invoicesetupid, startdate);
            }
        }

        public static void DeleteInvoice(string connection,string delete, string invoiceid)
        {
            if (delete == "Delete")
            {
                DataService.Controllers.Invoice.Delete(connection, invoiceid);
            }
        }

        public static void SearchInvoice(string connection,string search, string invoiceid)
        {
            if (search == "Search")
            {
                DataService.Controllers.Invoice.Search(connection, invoiceid);
            }
        }
        //[HttpPost]
        //public void PostInvoice( string create, string update, string search, string delete, string invoiceid, string customerid, string invoicesetupid, string supplierid, string startdate )
        //{
        //    if( create == "Create")
        //    {
        //    }
        //    if (update == "Update")
        //    {

        //    }
        //    if (search == "Search")
        //    {

        //    }
        //    if (delete == "Delete")
        //    {

        //    }
        //}

        //Lấy Dữ Liệu InvoiceLine
        [HttpGet]
        public static List<InvoiceLine> GetInvoiceLine(string connection)
        {
            DataTable table = DataService.Controllers.InvoiceLine.GetAll(connection);
            List<InvoiceLine> list = new List<InvoiceLine>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                InvoiceLine invoice = new InvoiceLine();
                invoice.ID = Convert.ToInt32(table.Rows[i]["ID"].ToString());
                invoice.InvoiceID = Convert.ToInt32(table.Rows[i]["InvoiceID"].ToString());
                invoice.Quantity = Convert.ToInt32(table.Rows[i]["Quantity"].ToString());
                invoice.Price = Convert.ToInt32(table.Rows[i]["Price"].ToString());
                invoice.ProductName = table.Rows[i]["ProductName"].ToString();
                invoice.CreateDate = Convert.ToDateTime(table.Rows[i]["CreateDate"].ToString());
                list.Add(invoice);
            }
            return list;
        }

        public static void CreateInvoiceLine(string connection,string create, string invoicelineid, string productname, string invoiceid, string quantity, string createdate, string price)
        {
            if (create == "Create")
            {
                DataService.Controllers.InvoiceLine.Create(connection, invoicelineid, productname, invoiceid, quantity, createdate, price);
            }
        }

        public static void UpdateInvoiceLine(string connection,string update, string invoicelineid, string productname, string invoiceid, string quantity, string createdate, string price)
        {
            if (update == "Update")
            {
                DataService.Controllers.InvoiceLine.Update(connection, invoicelineid, productname, invoiceid, quantity, createdate, price);
            }
        }

        public static void DeleteInvoiceLine(string connection,string delete, string invoicelineid, string productname, string invoiceid, string quantity, string createdate, string price)
        {
            if (delete == "Delete")
            {
                DataService.Controllers.InvoiceLine.Delete(connection, invoicelineid);
            }
        }

        public static void SearchInvoiceLine(string connection,string search, string invoicelineid, string productname, string invoiceid, string quantity, string createdate, string price)
        {
            if (search == "Search")
            {
                DataService.Controllers.InvoiceLine.Search(connection, invoicelineid);
            }
        }

        //Lấy Dữ Liệu InvoiceSetup
        [HttpGet]
        public static List<InvoiceSetup> GetInvoiceSetup(string connection)
        {
            DataTable table = DataService.Controllers.InvoiceSetup.GetAll(connection);
            List<InvoiceSetup> list = new List<InvoiceSetup>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                InvoiceSetup invoice = new InvoiceSetup();
                invoice.ID = Convert.ToInt32(table.Rows[i]["ID"].ToString());
                invoice.TypeName = table.Rows[i]["TypeName"].ToString();
                invoice.Symbol = table.Rows[i]["Symbol"].ToString();
                invoice.CreateBy = table.Rows[i]["CreateBy"].ToString();
                invoice.InvoiceStatus = table.Rows[i]["InvoiceStatus"].ToString();
                invoice.CreateOn = Convert.ToDateTime(table.Rows[i]["CreatedOn"].ToString());
                invoice.StartDate = Convert.ToDateTime(table.Rows[i]["StartDate"].ToString());
                list.Add(invoice);
            }
            return list;
        }

        public static void CreateInvoiceSetup(string connection,string create, string invoicesetupid, string typename, string symbol, string startdate, string createby, string invoicestatus, string createdon)
        {
            if (create == "Create")
            {
                DataService.Controllers.InvoiceSetup.Create(connection, invoicesetupid,typename, symbol, startdate, createby, invoicestatus, createdon);
            }
        }

        public static void UpdateInvoiceSetup(string connection,string update, string invoicesetupid, string typename, string symbol, string startdate, string createby, string invoicestatus, string createdon)
        {
            if (update == "Update")
            {
                DataService.Controllers.InvoiceSetup.Update(connection, invoicesetupid, typename, symbol, startdate, createby, invoicestatus, createdon);
            }
        }

        public static void DeleteInvoiceSetup(string connection,string delete, string invoicesetupid, string typename, string symbol, string startdate, string createby, string invoicestatus, string createdon)
        {
            if (delete == "Delete")
            {
                DataService.Controllers.InvoiceSetup.Delete(connection, invoicesetupid);
            }
        }

        public static void SearchInvoiceSetup(string connection,string search, string invoicesetupid)
        {
            if (search == "Search")
            {
                DataService.Controllers.InvoiceSetup.Search(connection, invoicesetupid);
            }
        }
    }
}
