using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Calci
    {
        static void Main(string[] args)
        {
            bool condi = true;
           
            while (condi)
            {
                Console.WriteLine("Enter the first number :");
                int Number1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Second number :");
                int Number2 = int.Parse(Console.ReadLine());
                int result = 0;
                Console.WriteLine("Choose the following operator to perform operations :");
                Console.WriteLine("+ .ADDITION");
                Console.WriteLine("- .SUBTRACTION");
                Console.WriteLine("* .MULTIPLICATION");
                Console.WriteLine("/ .DIVISION");
                Console.WriteLine("**************************");
                char Operator = char.Parse(Console.ReadLine());
                switch (Operator)
                {
                    case '+': result = Number1 + Number2;
                                 Console.WriteLine("The sum is : "+result);
                                break;
                    case '-':
                        result = Number1 - Number2;
                        Console.WriteLine(result);
                        break;
                    case '*':
                        result = Number1 * Number2;
                        Console.WriteLine(result);
                        break;
                    case '/':
                        if (Number2 != 0)
                        {
                            result = Number1 / Number2;
                            Console.WriteLine(result);
                        }
                        else Console.WriteLine("Not Possible");
                        break;
                    default: Console.WriteLine("Enter the operator");
                        break;
                }
                Console.WriteLine("enter 0 to abort calculation");
                Console.WriteLine("type any number to continue");
                int opt = Convert.ToInt32(Console.ReadLine());
                if (opt == 0)
                    condi = false;
        }
            Console.WriteLine("*********************************");
            Console.WriteLine("calculation ended");
        }
    }
}
