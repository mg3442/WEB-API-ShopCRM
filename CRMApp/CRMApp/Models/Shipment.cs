using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMApp.Model
{
  public class Shipment : Entity
    {
        public int? ShipmentID;
        public int OrderID;
        public int? Code;
        public DateTime ShipmentDate;

        public override string GetInfo()
        {
            return null;
        }

    }
}
