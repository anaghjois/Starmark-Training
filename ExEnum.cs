using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp
{
    class ExEnum
    {
        enum WeekDay
        {
            sun,mon,tue,wed,thur,fri,sat
        }
        static void Main(string[] args)
        {
            //WeekDay day = WeekDay.mon;
            Console.WriteLine("Enter the day to be selected : ");
            Array possibleDays = Enum.GetValues(typeof(WeekDay));
            for (int i=0; i < possibleDays.Length; i++){
                Console.WriteLine(possibleDays.GetValue(i));
            }
            object inputValue = Enum.Parse(typeof(WeekDay), Console.ReadLine(), true);
            WeekDay selectedDay = (WeekDay)inputValue;
            Console.WriteLine("The selected day is :" + selectedDay);
        }
    }
}
