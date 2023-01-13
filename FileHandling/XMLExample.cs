using System;
using System.Collections.Generic;
using SampleFrameworksApp.Practical;
using Assessment;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace SampleFrameworksApp.FileHandling
{
    class XMLExample
    {
        static void Main(string[] args)
        {
            var data = getAllCustomers("../../FileHandling/Customer.csv");
            writeToxml(data, "../../FileHandling/Customer.xml");
        }

        private static void writeToxml(Entity[] data, string fileName)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Customer Id", typeof(int));
            table.Columns.Add("CustomerName", typeof(string));
            table.Columns.Add("CustomerAddress", typeof(string));
            table.Columns.Add("BillAmount", typeof(int));
            foreach (var cst in data)
            {
                DataRow row = table.NewRow();
                row[0] = cst.CustomerId;
                row[1] = cst.CustomerName;
                row[2] = cst.CustomerAddress;
                row[3] = cst.BillAmount;
                table.Rows.Add(row);
            }
            table.AcceptChanges();
            DataSet ds = new DataSet("Customers");
            ds.Tables.Add(table);
            ds.WriteXml(fileName);


        }

        private static Entity[] getAllCustomers(string fileName)
        {
            List<Entity> allCustomers = new List<Entity>();
            var allLines = File.ReadAllLines(fileName);
            foreach (var line in allLines)
            {
                var words = line.Split(',');
                Entity entity = new Entity();
                entity.CustomerId = int.Parse(words[0]);
                entity.CustomerName = (words[1]);
                entity.BillAmount = int.Parse(words[2]);
                entity.CustomerAddress = words[3];
                allCustomers.Add(entity);
            }
            return allCustomers.ToArray();
        }
    }
}
