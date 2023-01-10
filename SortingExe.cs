using System;
using System.Collections.Generic;
using System.Linq;
using SampleFrameworksApp.Practical;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameworksApp
{
    class SortingExe
    {
        static void Main(string[] args)
        {
            sortingExampleOnCustomer();
           // sortingExampleOnString();
        }

        private static void sortingExampleOnString()
        {
            List<string> vs = new List<string>();
            vs.Add("Idris");
            vs.Add("Zafeer");
            vs.Add("Izmaan");
            vs.Add("Malli");
            vs.Add("Alfaaz");
            vs.Sort();
            foreach (var item in vs)
            {
                Console.WriteLine(vs);
            }
        }

        private static void sortingExampleOnCustomer()
        {
            List<Entity> entities = new List<Entity>();
            entities.Add(new Entity { CustomerId = 1, CustomerName = "David", BillAmount = 300, CustomerAddress = "Sagara" });
            entities.Add(new Entity { CustomerId = 2, CustomerName = "Zafeer", BillAmount = 550, CustomerAddress = "Arsikere" });
            entities.Add(new Entity { CustomerId = 3, CustomerName = "Alfaaz", BillAmount = 600, CustomerAddress = "Keladi" });
            entities.Add(new Entity { CustomerId = 4, CustomerName = "Bhavana", BillAmount = 500, CustomerAddress = "Bagalkot" });
            Console.WriteLine("Enter the Criteria to Sort");
            Array value = Enum.GetValues(typeof(Criteria));
            foreach (var item in value)
            {
                Console.WriteLine(item);
            }
            Criteria selected = (Criteria)Enum.Parse(typeof(Criteria), Console.ReadLine());
            entities.Sort(new CustomerComparer(selected));
            foreach (var cst in entities)
            {
                Console.WriteLine(cst);
            }
        }
    }
}
