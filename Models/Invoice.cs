using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceProject.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string IssuedDate { get; set; }
        public string DueDate { get; set; }
        public string CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CompanyName { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string CityName { get; set; }
        public string ZipCode { get; set; }
        public string SuburbName { get; set; }
        public string PhoneNumber { get; set; }
        public List<PurchaseList> AllPurchases { get; set; }

    }

    public class PurchaseList
    {
        public int ServiceId { get; set; }
        public string CustomerId { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int Qty { get; set; }
        public string ServiceDescription { get; set; }
        public string Taxed { get; set; }

    }


}