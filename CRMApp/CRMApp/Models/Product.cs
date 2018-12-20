using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMApp.Model
{
    public class Product : Entity
    {
        public int? ProductID;
        public string Name;
        public string Description;
      

        public override string GetInfo()
        {
            return string.Format(@"Product - ID:{0}, Name:{1}, Description:{2}",
                ProductID, Name, Description);
        }
    }
}
