using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp
{
    class alpha
    {
        public static void Alpha(string sentance)
        {
            int alpha = 0, dig = 0, spec = 0;
            for (int i = 0; i < sentance.Length; i++)
            {
                if (sentance[i] >= 'a' && sentance[i] <= 'z' || sentance[i] >= 'A' && sentance[i] <= 'Z')
                {
                    alpha++;
                }
                else if (sentance[i] >= '0' && sentance[i] <= '9')
                {
                    dig++;
                }
                else spec++;
            }
            Console.WriteLine("The count of Alphabets :"+alpha);
            Console.WriteLine("The count of Digits :" + dig);
            Console.WriteLine("The count of Special Characters :" + spec);
        }
    }
    class Alpha
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the sentance");
            string sen = Console.ReadLine();
            alpha.Alpha(sen);
        }
    }
}
