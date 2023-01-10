using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class reverse
    {
        public static string reverseByWords(string sentence)
        {
            string result = " ";
            string[] reverse = sentence.Split(' ');
            foreach ( string item in reverse)
            {
                result = item + " " + result;
            }
            return result; ;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the sentance");
            string sentence =Console.ReadLine();
            Console.WriteLine(reverseByWords(sentence)); 
        }
    }
}
