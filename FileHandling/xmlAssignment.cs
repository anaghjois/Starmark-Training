using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SampleFrameworksApp.FileHandling
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }

        public void Copy()
        {
            this.CustomerID = CustomerID;
            this.CustomerName = CustomerName;
            this.CustomerAddress = CustomerAddress;

        }
    }
    public class CustomerRepo
    {

     public    List<Customer> list = new List<Customer>();

        public void AddCustomer(Customer cst) => list.Add(cst);
        public void DeleteCustomer(int id)
        {
            foreach (var item in list)
            {
                if (id == item.CustomerID)
                {
                    list.Remove(item);
                }
            }
        }
        public void UpdateCustomer(int id)
        {
            foreach (var item in list)
            {
                if (id == item.CustomerID)
                {
                    item.Copy();
                }
            }
        }
        public Customer[] GetAllCustomer() => list.ToArray();
    }

    class xmlAssignment
    {
       static CustomerRepo customerRepo = new CustomerRepo();
        public static void addCustomerHelper()
        {

            customerRepo.AddCustomer(new Customer { CustomerID = 100, CustomerName = "parethesis", CustomerAddress = "mysuru" });
            customerRepo.AddCustomer(new Customer { CustomerID = 101, CustomerName = "flower barcis", CustomerAddress = "shivamoga" });
            customerRepo.AddCustomer(new Customer { CustomerID = 102, CustomerName = "square pants", CustomerAddress = "bagalkote" });
            xmlSrializable();
        }
        public static void DeleteHelper()
        {
            List<Customer> customers= deserializeExample();
            foreach (var item in customers)
            {
                if (100 == item.CustomerID)
                {
                    customers.Remove(item);
                    break;
                }
            }
            xmlSrializable();
        }
       
        public static void xmlSrializable()
        {
            FileStream fs = new FileStream("list.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer formatter = new XmlSerializer(typeof(List<Customer>));
            formatter.Serialize(fs, customerRepo.list);
            fs.Close();
        }
        public static List<Customer> deserializeExample()
        {
            List<Customer> customers = null;
            FileStream fs = new FileStream("list.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer fm = new XmlSerializer(typeof(List<Customer>));
            customers = fm.Deserialize(fs) as List<Customer>;
            fs.Close();
            return customers;
        }
        static void Main(string[] args)
        {
            //addCustomerHelper();
            DeleteHelper();
        }
    }
}
