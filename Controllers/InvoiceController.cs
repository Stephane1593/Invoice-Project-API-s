using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using InvoiceProject.Models;

namespace InvoiceProject.Controllers
{
    public class InvoiceController : ApiController
    {
        // Retrieve all invoices
        public HttpResponseMessage Get()
        {
            string query = @"select * from dbo.Invoice";
            TableController request = new TableController();
            return Request.CreateResponse(HttpStatusCode.OK, request.readTable(query, "InvoiceAppDB"));
        }


        // Insert user details and placed orders
        // retrieve invoice details based on customerID
        public async Task<DataTable> Post(Invoice inv)
        {
            try
            {
                // insert  details ------------------
                string query = @"insert into dbo.Invoice values
                     (
                     '" + inv.IssuedDate + @"', 
                     '" + inv.DueDate + @"', 
                     '" + inv.CustomerId + @"', 
                     '" + inv.CustomerFirstName + @"', 
                     '" + inv.CustomerLastName + @"', 
                     '" + inv.CompanyName + @"', 
                     '" + inv.StreetName + @"',
                     '" + inv.StreetNumber + @"', 
                     '" + inv.CityName + @"', 
                     '" + inv.ZipCode + @"', 
                     '" + inv.SuburbName + @"', 
                     '" + inv.PhoneNumber + @"')";
                TableController request = new TableController();          
                await request.readTable(query, "InvoiceAppDB");

               
                await Task.Run(() => {
                    PurchaseController services = new PurchaseController();
                    services.Post(inv);
                });
                // ----------------------------------------------

                // retrieve invoice detials based on customerID
                string q = @"select * from dbo.Invoice where CustomerId = '" + inv.CustomerId + @"'";
                DataTable d1 = await request.readTable(q, "InvoiceAppDB");
                

           
                string qu = @"select * from dbo.Purchase where CustomerId = '" + inv.CustomerId + @"'";
                DataTable d2 =  await request.readTable(qu, "InvoiceAppDB");

                DataTable dtALL = d1.Copy();
                dtALL.Merge(d2);

                return dtALL;

            }
            catch (Exception ex)
            {
                DataTable value = new DataTable();
                return value;
            }
        }
    }
}
