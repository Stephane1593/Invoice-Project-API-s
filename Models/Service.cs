using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceProject.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public int Price { get; set; }
        public int TotalPrice { get; set; }
        public int Qty { get; set; }
        public string ServiceDescription { get; set; }
        public string Taxed { get; set; }
    }
}