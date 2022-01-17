using System;
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
using System.Threading.Tasks;

namespace InvoiceProject.Controllers
{
    public class TableController : ApiController
    {
        // read data from the database
        // general method for table read
        public Task<DataTable> readTable(string query, string DB)
        {
            DataTable returnValue = null;
            try
            {
                return Task.Run(() =>
                {
                    DataTable table = new DataTable();
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[DB].ConnectionString))
                    using (var cmd = new SqlCommand(query, con))
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        da.Fill(table);
                        return table;
                    }
                });

              
            }catch(Exception ex )
            {
               var ErrorString = ex.Message;
            }

            return Task.Run(() => { return returnValue; });

        }
    }
}
