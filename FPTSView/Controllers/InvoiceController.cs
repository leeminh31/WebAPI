using ClosedXML.Excel;
using System;
using System.Collections.Generic;
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
        // GET: Invoice
        public ActionResult Invoice()
        {
            return View();
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
            return View();
        }

        public ActionResult InvoiceSetup()
        {
            return View();
        }
    }
}