using System;
using DataLayer;
using UtilitiesLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameworksApp.Practical
{
    class UI
    {
        static ICustomer component = null;
        static UI()
        {
            // Console.WriteLine("Enter the Name of the Component as : List or ArrayList");
            //component = CustomerFactory.GetComponent(Console.ReadLine());
        }
        public static void FactoryTesting()
        {
            component.AddCustomer(new Entity { CustomerId = 111, CustomerName = "Ramesh Adiga", CustomerAddress = "Kundapur", BillAmount = 5600 });

            component.UpdateCustomer(new Entity { CustomerId = 111, CustomerName = "Ramesh Adiga", CustomerAddress = "Udupi", BillAmount = 5600 });
            // component.DeleteCustomer(111);
            var data = component.GetAllCustomer();
            foreach (Entity customer in data)
            {
                Console.WriteLine(customer.BillAmount);
                component.DeleteCustomer(111);
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }

        static void Main(string[] args)
        {
            //  FactoryTesting();
            HashSetCollection hashSetCollection = new HashSetCollection();
            hashSetCollection.AddNewCustomer(new Entity { CustomerId = 123, CustomerName = "Anagha K V", CustomerAddress = "Sagaraa", BillAmount=1234 });
            hashSetCollection.AddNewCustomer(new Entity { CustomerId = 124, CustomerName = "Anagha Jois", CustomerAddress = "Sagar", BillAmount=1234 });
            hashSetCollection.AddNewCustomer(new Entity { CustomerId = 125, CustomerName = "Anaghaaa", CustomerAddress = "Keladi", BillAmount=1234 });
            hashSetCollection.AddNewCustomer(new Entity { CustomerId = 126, CustomerName = "Anagh", CustomerAddress = "Bengaluru", BillAmount=1234 });
            hashSetCollection.AddNewCustomer(new Entity { CustomerId = 123, CustomerName = "Anagha K V", CustomerAddress = "Shimoga", BillAmount=1234 });

            Console.WriteLine("Total number of customers "+hashSetCollection.Allcustomers.Count);
            foreach (var cust in hashSetCollection.Allcustomers)
            {
                Console.WriteLine(cust);
            }
        }

    }
}
