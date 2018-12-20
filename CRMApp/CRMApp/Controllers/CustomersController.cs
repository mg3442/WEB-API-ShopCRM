using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRMApp.Model;
using CRMApp.Business;
using System.Data.SqlClient;

namespace CRMApp.Controllers
{
    public class CustomersController : ApiController
    {
        protected CustomerService _service;

        public CustomersController()
        {
            _service = new CustomerService();
        }

        public IList<Customer> GetAll()
        {
            var items = _service.LoadAll();
            return items;
        }

        public IHttpActionResult Get(int id)
        {
            var item = _service.Load(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
    }
}
