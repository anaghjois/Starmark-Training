using System;
using System.Diagnostics;

namespace SampleApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter your name :");
            string myName = Console.ReadLine();
            Console.WriteLine("Enter your Age :");
            int myAge =int.Parse( Console.ReadLine());
            Console.WriteLine("Enter your Address :");
            string myAddress = Console.ReadLine();
            Debug.WriteLine("Address" + myAddress);
            Console.WriteLine($"My name is {myName} and I'm {myAge} year old and I come from {myAddress}");
        }
    }
}
