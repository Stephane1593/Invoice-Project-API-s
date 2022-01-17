using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InvoiceProject.Controllers
{
    public class ServiceController : ApiController
    {
        // Retrieve all services
        public HttpResponseMessage Get()
        {
            string query = @"select * from dbo.ServiceList";
            TableController request = new TableController();
            return Request.CreateResponse(HttpStatusCode.OK, request.readTable(query, "InvoiceAppDB"));
        }
    }
}
