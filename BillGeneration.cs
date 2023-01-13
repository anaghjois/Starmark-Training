using System;
using Assessment;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameworksApp
{
    class Bill
    {
        public static int BillId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int Amount { get; set; }
    }
    class Item
    {
        static int idcount=0;
        public  int ItemId { get; private set; }
        public string Particulars { get; set; }
        public int UnitPrice { get; set; }
        public Item()
        {
            idcount++;
            ItemId = idcount;
        }
    }
    class ItemManager
    {
        Bill bill = new Bill();
        public Item item = null;
        List<Item> items = new List<Item>();
        public int amount = 0;
         public void AddItems()
        {
            items.Add(new Item { Particulars="soap",UnitPrice=45 });
            items.Add(new Item { Particulars="Chips",UnitPrice=35 });
            items.Add(new Item { Particulars="Oreo",UnitPrice=55 });
            items.Add(new Item { Particulars="Deodrant",UnitPrice=145 });
            items.Add(new Item { Particulars="Toothpaste",UnitPrice=25 });
        }
        public void calculateBill()
        {
            Console.WriteLine("The Following Items are there in our store : ");
            foreach (var data in items)
            {
                Console.WriteLine(data.ItemId+" : "+data.Particulars+" : "+data.UnitPrice);
            }
            Console.WriteLine();
            string name = Utilities.Prompt("Enter the name of the customer");
            Console.WriteLine();
            bool choice = true;
            ArrayList Enteredid = new ArrayList();
            ArrayList quantity = new ArrayList();
            do
            {
                int id = Utilities.GetNumber("Enter the Item Id :");
                int Quantity = Utilities.GetNumber("Enter the Quantity");
                if (Enteredid.Contains(id))
                {
                    int index = Enteredid.IndexOf(id);
                    int temp = (int)quantity[index] + Quantity;
                    quantity.Insert(index, temp);
                }
                else
                {
                    Enteredid.Add(id);
                    quantity.Add(Quantity);
                }
                amount += BillCalculator(id) * Quantity;
                //Console.WriteLine(amount);
            RETRY:
                int response = Utilities.GetNumber("Enter 0 to generate bill\n Enter 1 to continue Adding item");
                if (response == 1) choice = true;
                else if (response == 0) choice = false;
                else
                {
                    Console.WriteLine("Invalid Entry");
                    goto RETRY;
                }
            } while (choice);
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Bill Number "+bill.GetHashCode());
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Name : "+name+"                             "+DateTime.Now.ToShortDateString());

            Console.WriteLine("id\tName\tPrice\tQuantity\tTotal");
            Console.WriteLine("-----------------------------------------------------");
            int count = 0;

            foreach ( int values in Enteredid)
            {
                Console.Write(values + "   ");
                Console.Write(NameofItem(values)+ "\t");
                Console.Write(quantity[count] +"\t");
                Console.Write(BillCalculator(values)*(int)quantity[count]);
                count++;
                Console.WriteLine();
            }
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Total Bill : "+amount);
           
        }

        private string NameofItem(int values)
        {
            foreach (var data in items)
            {
                if (values == data.ItemId)
                {
                    return data.Particulars;
                }
            }
            return null;
        }

        private int BillCalculator(int id)
        {
            foreach (var item in items)
            {
                if (id == item.ItemId)
                {
                    return item.UnitPrice;
                }
            }
            return 0;
        }
    }
    class BillGeneration
    {
        static void Main(string[] args)
        {
            ItemManager itemManager = new ItemManager();
            itemManager.AddItems();
            itemManager.calculateBill();
        }
    }
}
