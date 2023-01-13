using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesLayer
{
   static class CustomerFactory
    {
        public static ICustomer GetComponent(string type)
        {
            ICustomer component = null;
            switch (type.ToLower())
            {
                case "list": return new ListCollection();
                case "arraylist": return new CustomerRepo();
                default:
                    throw new Exception("This type is not supported by us");
            }
        }
    }
}
