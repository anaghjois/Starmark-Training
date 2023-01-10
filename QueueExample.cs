using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleFrameworksApp
{
    class QueueExample
    {
        private Queue<string> vs = new Queue<string>();

        static void Main(string[] args)
        {
            //QueueExample queueExample = new QueueExample();
            //do
            //{
            //    Console.WriteLine("Enter the Item");
            //    var input = Console.ReadLine();
            //    queueExample.viewItem(input);
            //} while (true);
            sortedListExample();

        }

        private static void sortedListExample()
        {
            SortedList<string, long> sort = new SortedList<string, long>();
            sort.Add("idris", 6969696);
            sort.Add("Anagha", 4485965);
            sort.Add("Gagan", 420640);
            sort.Add("areeb", 6969696);
            foreach (var item in sort)
            {
                Console.WriteLine($"{item.Key}-{item.Value}");
            }

        }

        public  void viewItem(string item)
        {
            if (vs.Count == 3) vs.Dequeue();
            vs.Enqueue(item);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(item);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Our Items : ");
            var data = vs.Reverse();
            foreach (var element in data)
            {
                Console.WriteLine("-----------");
                Console.WriteLine(element);
                Console.WriteLine("-----------");
            }

        }
    }
}
