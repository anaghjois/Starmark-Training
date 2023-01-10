using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp
{
    class Example
    {
        public Example()
        {
            Console.WriteLine("Anagha");
        }
        static int ValueType = 1509;
        static Example()
        {
            Console.WriteLine("hi how are you");
        }
        class staticClass
        {
            static void Main(string[] args)
            {
                //Example example = new Example();
                Example.ValueType = 121212;
            }
        }
    }
}
