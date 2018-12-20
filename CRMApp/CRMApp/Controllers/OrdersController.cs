using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRMApp.Model;
using CRMApp.Bussines;

namespace CRMApp.Controllers
{
    public class OrdersController : ApiController
    {
        protected OrderService _service;

        public OrdersController()
        {
            _service = new OrderService();
        }

        public IList<Order> GetAll()
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
