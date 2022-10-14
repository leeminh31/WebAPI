using ClosedXML.Excel;
using FPTS_API.Models;
using FPTSView.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace FPTS_API.Controllers
{
    public class InvoiceController : Controller
    {
        string connection = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        // GET: Invoice
        [HttpGet]
        public ActionResult Invoice()
        {
            List<FPTS_API.Models.Invoice> invoices = FPTS_API.Controllers.InvoiceAPIController.GetInvoice(connection);
            return View(invoices);
        }


        [HttpPost]
        public ActionResult Invoice(string invoiceid)
        {
            List<FPTS_API.Models.Invoice> invoices = FPTS_API.Controllers.InvoiceAPIController.SearchInvoice(connection, invoiceid);
            
            return View(invoices);
        }

        [HttpPost]
        public ActionResult CreateInvoice (string customerid, string supplierid, string invoiceid, string invoicesetupid, string startdate)
        {
            FPTS_API.Controllers.InvoiceAPIController.CreateInvoice(connection,invoiceid,customerid,invoicesetupid,supplierid,startdate);
            return Redirect(Url.Action("Invoice", "Invoice"));
        }

        [HttpPost]
        public ActionResult UpdateInvoice(string customerid, string supplierid, string invoiceid, string invoicesetupid, string startdate)
        {
            FPTS_API.Controllers.InvoiceAPIController.UpdateInvoice(connection, invoiceid, customerid, invoicesetupid, supplierid, startdate);
            return Redirect(Url.Action("Invoice", "Invoice"));
        }

        [HttpPost]
        public ActionResult DeleteInvoice(string invoiceid)
        {
            FPTS_API.Controllers.InvoiceAPIController.DeleteInvoice(connection, invoiceid);
            return Redirect(Url.Action("Invoice", "Invoice"));
        }

        [HttpPost]
        public void ExportInvoice(string export)
        {
                DataTable table = new DataTable();
                List<Invoice> invoices = FPTS_API.Controllers.InvoiceAPIController.GetInvoice(connection);
                foreach(Invoice invoice in invoices)
                {
                    DataRow row = table.NewRow();
                    row["InvoiceID"] = invoice.InvoiceId;
                    row["InvoiceSetupID"] = invoice.InvoiceSetupId;
                    row["StartDate"] = invoice.StartDate;
                    row["SupplierID"] = invoice.SupplierId;
                    row["InvoiceCode"] = invoice.InvoiceCode;
                    row["Customer"] = invoice.CustomerId;
                    table.Rows.Add(row);
                }
                using (XLWorkbook workbook = new XLWorkbook())
                {
                    table.TableName = "Invoice";
                    workbook.Worksheets.Add(table);
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Invoice.xlsx");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        workbook.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                    }
                }
                Response.Flush();
                Response.End();
        }

        public ActionResult InvoiceLine()
        {
            List<FPTS_API.Models.InvoiceLine> invoices = FPTS_API.Controllers.InvoiceAPIController.GetInvoiceLine(connection);
            return View(invoices);
        }

        [HttpPost]
        public ActionResult CreateInvoiceLine(string invoicelineid, string productname, string invoiceid, string quantity, string createdate, string price)
        {
            FPTS_API.Controllers.InvoiceAPIController.CreateInvoiceLine(connection,invoicelineid, productname, invoiceid, quantity, createdate, price);
            return Redirect(Url.Action("InvoiceLine", "Invoice"));
        }

        [HttpPost]
        public ActionResult UpdateInvoiceLine(string invoicelineid, string productname, string invoiceid, string quantity, string createdate, string price)
        {
            FPTS_API.Controllers.InvoiceAPIController.UpdateInvoiceLine(connection, invoicelineid, productname, invoiceid, quantity, createdate, price);
            return Redirect(Url.Action("InvoiceLine", "Invoice"));
        }

        [HttpPost]
        public ActionResult InvoiceLine(string invoicelineid)
        {
            List<FPTS_API.Models.InvoiceLine> invoicelines = FPTS_API.Controllers.InvoiceAPIController.SearchInvoiceLine(connection, invoicelineid);
            return View(invoicelines);
        }

        [HttpPost]
        public ActionResult DeleteInvoiceLine(string invoicelineid)
        {
            FPTS_API.Controllers.InvoiceAPIController.DeleteInvoiceLine(connection, invoicelineid);
            return Redirect(Url.Action("InvoiceLine", "Invoice"));
        }

        public ActionResult InvoiceSetup()
        {
            List<FPTS_API.Models.InvoiceSetup> invoices = FPTS_API.Controllers.InvoiceAPIController.GetInvoiceSetup(connection);
            return View(invoices);
        }

        [HttpPost]
        public ActionResult CreateInvoiceSetup(string invoicesetupid, string typename, string symbol, string startdate, string createby, string invoicestatus, string createdon)
        {
            FPTS_API.Controllers.InvoiceAPIController.CreateInvoiceSetup(connection,invoicesetupid, typename, symbol, startdate, createby, invoicestatus, createdon);
            return Redirect(Url.Action("InvoiceSetup", "Invoice"));
        }

        [HttpPost]
        public ActionResult UpdateInvoiceSetup(string invoicesetupid, string typename, string symbol, string startdate, string createby, string invoicestatus, string createdon)
        {
            FPTS_API.Controllers.InvoiceAPIController.UpdateInvoiceSetup(connection,invoicesetupid, typename, symbol, startdate, createby, invoicestatus, createdon);
            return Redirect(Url.Action("InvoiceSetup", "Invoice"));
        }

        [HttpPost]
        public ActionResult InvoiceSetup(string invoicesetupid)
        {
            List<FPTS_API.Models.InvoiceSetup> invoicesetups = FPTS_API.Controllers.InvoiceAPIController.SearchInvoiceSetup(connection, invoicesetupid);
            return View(invoicesetups);
        }

        [HttpPost]
        public ActionResult DeleteInvoiceSetup(string invoicesetupid)
        {
            FPTS_API.Controllers.InvoiceAPIController.DeleteInvoiceSetup(connection,invoicesetupid);
            return Redirect(Url.Action("InvoiceSetup", "Invoice"));
        }
    }
}