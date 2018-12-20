using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMApp.Model
{
   public class Subscription : Entity
    {
        public int? SubscriptionID;
        public int? ProductID;
        public string Name;
        public int Price;
        public int Amount;
       

        public override string GetInfo()
        {
            return string.Format(@"Subscription - ID:{0}, ProductID:{1}, Name:{2}, Price:{3}, Amount{4}",
                SubscriptionID, ProductID, Name, Price, Amount);
        }
    }
}
