using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp
{
    class TypeConvert
    {
        static void Main()
        {
            Console.WriteLine($"The range of byte is{byte.MinValue} to {byte.MaxValue} ");
            Console.WriteLine($"The range of int is{int.MinValue} to {int.MaxValue} ");
            Console.WriteLine($"The range of long is{long.MinValue} to {long.MaxValue} ");
            Console.WriteLine($"The range of  double is{double.MinValue} to {double.MaxValue} ");
            Console.WriteLine($"The range of char is{char.MinValue} to {char.MaxValue} ");
         


            long ivalue = long.MaxValue;
            
                int value = (int)ivalue;
                Console.WriteLine(value);
           
        }
    }
}
