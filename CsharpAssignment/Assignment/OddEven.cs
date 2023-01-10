using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class OddEven
    {
        static void Main(string[] args)
        {
            int[] values = { 1, 5, 3, 9, 8, 24, 25, 33, 21, 44 };

            foreach (var result in values)
            {
                if (result % 2 == 0)
                {
                    Console.WriteLine(result + " is Even Value");
                }
                else
                {
                    Console.WriteLine(result + " is Odd Value");
                }
            }
        }
    }
}
