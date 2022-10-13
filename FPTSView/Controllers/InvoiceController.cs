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
        public ActionResult Invoice()
        {
            List<FPTS_API.Models.Invoice> invoices = FPTS_API.Controllers.InvoiceAPIController.GetInvoice(connection);
            return View(invoices);
        }

        //[HttpPost]
        //public ActionResult Invoice(string create, string search, string refresh, string update, string delete, string export, string customerid, string supplierid, string invoiceid, string invoicesetupid, string startdate)
        //{
        //    DataTable table = new DataTable();
        //    if (create == "Create")
        //    {
        //        handleCreateInvoice(invoiceid, customerid, supplierid, invoicesetupid, startdate);
        //    }
        //    if (search == "Search")
        //    {
        //        return View(handleSearchInvoice(invoiceid));
        //    }
        //    if (refresh == "Refresh")
        //    {
        //        return View(handleRefresh("tb_invoice"));
        //    }
        //    if (update == "Update")
        //    {
        //        handleUpdateInvoice(customerid, supplierid, invoiceid, invoicesetupid, startdate);
        //    }
        //    if (delete == "Delete")
        //    {
        //        handleDeleteInvoice(invoiceid);
        //    }
        //    if (export == "Export")
        //    {
        //        using (XLWorkbook workbook = new XLWorkbook())
        //        {
        //            table.TableName = "Invoice";
        //            workbook.Worksheets.Add(table);
        //            Response.Clear();
        //            Response.Buffer = true;
        //            Response.Charset = "";
        //            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //            Response.AddHeader("content-disposition", "attachment;filename=Invoice.xlsx");
        //            using (MemoryStream MyMemoryStream = new MemoryStream())
        //            {
        //                workbook.SaveAs(MyMemoryStream);
        //                MyMemoryStream.WriteTo(Response.OutputStream);
        //            }
        //        }
        //        Response.Flush();
        //        Response.End();
        //    }
        //    return View();
        //}

        public ActionResult InvoiceLine()
        {
            List<FPTS_API.Models.InvoiceLine> invoices = FPTS_API.Controllers.InvoiceAPIController.GetInvoiceLine(connection);
            return View(invoices);
        }

        public ActionResult InvoiceSetup()
        {
            List<FPTS_API.Models.InvoiceSetup> invoices = FPTS_API.Controllers.InvoiceAPIController.GetInvoiceSetup(connection);
            return View(invoices);
        }
    }
}