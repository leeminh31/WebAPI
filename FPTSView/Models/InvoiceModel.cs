using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPTSView.Models
{
    public class InvoiceModel
    {
        public int CustomerID { get; set; }
        public int InvoiceID { get; set; }
        public int SupplierID { get; set; }
        public int InvoiceSetupID { get; set; }
        public string InvoiceCode { get; set; }
        public DateTime StartDate { get; set; }
    }
}