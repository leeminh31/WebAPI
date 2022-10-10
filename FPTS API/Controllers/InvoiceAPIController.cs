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
        string connection = System.Configuration.ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        
        // Hàm Lấy Dữ Liệu
        public DataTable refresh(string name)
        {
            DataTable table = new DataTable();
            using (SqlConnection cnn = new SqlConnection(connection))
            {
                cnn.Open();
                string query = "select * from " + name;
                SqlDataAdapter adapter = new SqlDataAdapter(query, cnn);
                adapter.Fill(table);
            }
            return table;
        }

        // Lấy Dữ Liệu Invoice
        [HttpGet]
        public List<Invoice> GetInvoice()
        {
            DataTable table = refresh("tb_invoice");
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

        //Lấy Dữ Liệu InvoiceLine
        [HttpGet]
        public List<InvoiceLine> GetInvoiceLine()
        {
            DataTable table = refresh("tb_invoice_line");
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

        //Lấy Dữ Liệu InvoiceSetup
        [HttpGet]
        public List<InvoiceSetup> GetInvoiceSetup()
        {
            DataTable table = refresh("tb_invoice_setup");
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
    }
}
