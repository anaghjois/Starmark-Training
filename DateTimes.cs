using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp
{
    class DateTimes
    {
        static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;
            //Console.WriteLine("The date is :"+dt);
            //Console.WriteLine(dt.Second);
            //Console.WriteLine(dt.Ticks);
            //Console.WriteLine(dt.Kind);
            //Console.WriteLine(dt.ToLongDateString());
            //Console.WriteLine(dt.ToShortDateString());
            //Console.WriteLine(dt.ToLongTimeString());
            //Console.WriteLine(dt.ToShortTimeString());
            //Console.WriteLine(dt.ToString("dd/MM/yyyy"));
            //Console.WriteLine($"{dt.Date}/{dt.Month}/{dt.Year}");
            //Console.WriteLine("Enter a date");
            //dt = DateTime.Parse(Console.ReadLine());
            //Console.WriteLine(dt);

            //Console.WriteLine("Enter the date as dd/MM/yyyy");
            //dt = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            //Console.WriteLine("Enter the Date of Birth");
            //dt = DateTime.Parse(Console.ReadLine());
            //var currDate = DateTime.Now;
            //var span = DateTime.Now - dt;
            //Console.WriteLine("The no of Days: " + span.TotalDays);
            //Console.WriteLine("The no of Years: " + (currDate.Year - dt.Year));
            //Random random = new Random();
            //for (int i = 0; i < 100; i++)
            //{
            //    int no = random.Next(10, 50);
            //    Console.WriteLine("The Date entered: " + currDate.AddDays(no).ToLongDateString());
            //    Thread.Sleep(2000);
            //}

            Console.WriteLine("Enter a date");
            dt = DateTime.Parse(Console.ReadLine());
            for (int i = -1; i >= -15; i--)
            {
                Console.WriteLine("The old date is :"+dt.AddYears(i));
            }

        }
    }
}
