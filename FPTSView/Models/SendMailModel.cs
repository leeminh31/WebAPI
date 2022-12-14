using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPTSView.Models
{
    public class SendMailModel
    {
        public string InvoiceCode { get; set; }
        public string Fullname { get; set; }
        public string CustomerAddress { get; set; }
        public string Email { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public bool IsChecked { get; set; }
    }
}