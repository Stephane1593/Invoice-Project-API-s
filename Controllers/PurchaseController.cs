using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InvoiceProject.Models;

namespace InvoiceProject.Controllers
{
    public class PurchaseController : ApiController
    {
        // Insert new orders from client
        public string Post(Invoice inv)
        {
            try
            {
                string query = @"insert into dbo.Purchase values (@ServiceId, @CustomerId, @Price, @TotalPrice, @Qty, @ServiceDescription, @Taxed)";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["InvoiceAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    for (int i = 0; i < inv.AllPurchases.Count; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ServiceId", inv.AllPurchases[i].ServiceId);
                        cmd.Parameters.AddWithValue("@CustomerId", inv.AllPurchases[i].CustomerId);
                        cmd.Parameters.AddWithValue("@Price", inv.AllPurchases[i].Price);
                        cmd.Parameters.AddWithValue("@TotalPrice", inv.AllPurchases[i].TotalPrice);
                        cmd.Parameters.AddWithValue("@QTY", inv.AllPurchases[i].Qty);
                        cmd.Parameters.AddWithValue("@ServiceDescription", inv.AllPurchases[i].ServiceDescription);
                        cmd.Parameters.AddWithValue("@Taxed", inv.AllPurchases[i].Taxed);
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
                return "Added successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
