using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameworksApp.Practical
{
    class Entity :IComparable<Entity>
    {
            public int CustomerId { get; set; }
            public string CustomerName { get; set; }
            public string CustomerAddress { get; set; }
            public int BillAmount { get; set; }
        public void copy(Entity cst)
        {
            CustomerId = cst.CustomerId;
            CustomerName = cst.CustomerName;
            CustomerAddress = cst.CustomerAddress;
            BillAmount = cst.BillAmount;
        }
        public override int GetHashCode()
        {
            return CustomerId.GetHashCode();
        }
       
        public override bool Equals(object obj)
        {
            if(obj is Entity)
            {
                var unBoxed = obj as Entity;
                if (CustomerId == unBoxed.CustomerId&&CustomerName==unBoxed.CustomerName) return true;
            }
            return false;
        }
        public override string ToString()
        {
            return $"Id :{CustomerId} , address :{CustomerAddress} , Name :{CustomerName} , Bill :{BillAmount}";
        }

        public int CompareTo(Entity other)
        {
            return BillAmount.CompareTo(other.BillAmount);
        }
    }
    enum Criteria { ID,Name,Address,Bill}
    class CustomerComparer : IComparer<Entity>
    {
        private Criteria criteria;
        public CustomerComparer(Criteria criteria)
        {
            this.criteria = criteria;
        }

        public int Compare(Entity x, Entity y)
        {
            switch (criteria)
            {
                case Criteria.ID:
                    return x.CustomerId.CompareTo(y.CustomerId);
                case Criteria.Name:
                   return x.CustomerName.CompareTo(y.CustomerName);
                case Criteria.Address:
                    return x.CustomerAddress.CompareTo(y.CustomerAddress);
                case Criteria.Bill:
                    return x.CompareTo(y);
                default:
                    break;
            }
            return 0;
        }
    }
   
}
