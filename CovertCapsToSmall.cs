using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp
{
    class convert
    {
        public static void Convert(string sent)
        {
            string finalString = "";
            char[] strchararr = sent.ToCharArray();
            for (int i = 0; i < strchararr.Length; i++)
            {

                if (strchararr[i] >= 'a' && strchararr[i] <= 'z')
                {
                    finalString += char.ToUpper(strchararr[i]);

                }

                else if (strchararr[i] >= 'A' && strchararr[i] <= 'Z')
                {
                    finalString += char.ToLower(strchararr[i]);
                }
                //else
                //{
                //    finalString += strchararr[i];
                //}
            }
            Console.WriteLine(finalString);
            
        }
    }
    class CovertCapsToSmall
    {
        static void Main()
        {
            
            Console.WriteLine("Enter the string");
            string str = Console.ReadLine();
                convert.Convert(str);
            
        }
    }
}
