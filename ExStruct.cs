using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp
{       
    public struct Student
    {
        public int USN { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public long Phn { get; set; }

        public string GetAllDetails()
        {
            return $"The USN {USN}, name {Name} is from {Address} & phone number is {Phn}";
        }
    }
    class ExStruct
    {
        static void Main(string[] args)
        {
            Student s = new Student { USN = 100, Name = "Idris", Address = "Arsikere", Phn = 9944339944 };
            Console.WriteLine(s.GetAllDetails());
        }
        
    }
}
