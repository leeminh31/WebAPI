using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPTS_API.Models
{
    public class Invoice
    {
        public int CustomerId { get; set; }
        public int InvoiceId { get; set; }
        public int SupplierId { get; set; }
        public int InvoiceSetupId { get; set; }
        public string InvoiceCode { get; set; }
        public DateTime StartDate { get; set; }
    }

    public class InvoiceList 
    { 
        public List<Invoice> Invoices { get; set; }
    }

}