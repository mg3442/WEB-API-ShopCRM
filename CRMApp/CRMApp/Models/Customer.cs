using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMApp.Model
{
    public class Customer : Entity
    {
        public int? CustomerID;
        public string FirstName;
        public string LastName;
        public string Address;
        public string City;
        public string Email;

        public override string GetInfo()
        {
            return string.Format(@"Customer - ID:{0}, FirstName:{1}, LastName:{2}",
                CustomerID, FirstName, LastName);
        }
    }
}
