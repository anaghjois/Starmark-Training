using System;
using System.IO;
using SampleFrameworksApp.Practical;
using Assessment;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameworksApp.FileHandling
{
    class CSVReadingWriting
    {
        const string fileName = "../../FileHandling/Customer.csv";
        static void Main(string[] args)
        {
            var choice = Utilities.Prompt("What do you wan to do A. Add or V.View ?");
            if (choice.ToUpper() == "A") FileWrite();
            else if (choice.ToUpper() == "V") FileRead();
            else Console.WriteLine("Invalid Choice");
        }

        private static void FileRead()
        {
            List<Entity> entities = new List<Entity>();
            var allLines = File.ReadAllLines(fileName);
            foreach (var line in allLines)
            {
                var words = line.Split(',');
                Entity entity = new Entity();
                entity.CustomerId = int.Parse(words[0]);
                entity.CustomerName =(words[1]);
                entity.BillAmount = int.Parse(words[2]);
                entity.CustomerAddress = words[3];
                entities.Add(entity);
            }
            foreach (var item in entities)
            {
                Console.WriteLine(item.CustomerName+" "+item.BillAmount);
            }
        }

        private static void FileWrite()
        {
            Entity cst = new Entity {
                CustomerId = Utilities.GetNumber("Enter the Customer Id"),
                CustomerName = Utilities.Prompt("Enter the Cutomer Name"),
                BillAmount = Utilities.GetNumber("Enter the bill"),
            CustomerAddress=Utilities.Prompt("Enter the address")};
            File.AppendAllText(fileName, cst.ToString());
        }
    }
}
