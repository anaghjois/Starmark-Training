using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp
{
    class ExArray
    {
        static void Main(string[] args)
        {
            string[] Name ={ "Vinayak", "Sachin", "Eshwar", "Aravind", "Shrusti" };
            Console.WriteLine("size of the array is" + Name.Length);
            Console.WriteLine("dimension of array"+Name.Rank);
            Console.WriteLine("length of first dimension"+Name.GetLength(0));
            foreach (string name in Name)
            {
                Console.WriteLine(name);
            }
            int[,] numbers = { { 1, 2, 3 }, { 4, 5, 6 } };
            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                string row = "";
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    row += numbers[i, j] + " ";
                }
                Console.Write(row.TrimEnd());
                Console.WriteLine();

            }

        }
    }
}
