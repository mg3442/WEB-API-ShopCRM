using CRMApp.Bussines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRMApp.Model;

namespace CRMApp.Controllers
{
    public class ShipmentsController : ApiController
    {
        protected ShipmentService _service;

        public ShipmentsController()
        {
            _service = new ShipmentService();
        }

        public IList<Shipment> GetAll()
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
