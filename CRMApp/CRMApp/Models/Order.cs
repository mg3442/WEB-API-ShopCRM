using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMApp.Model
{
  public class Order : Entity
    {
        public int? OrderId;
        public int? SubscriptionID;
        public int? CustomerID;
        public DateTime CreateDate;

        public override string GetInfo()
        {
            return null;
        }
    }
}
