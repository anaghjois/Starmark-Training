using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp
{
    class Employee
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int salary { get; set; }
        public static Employee operator +(Employee emp, int amount)
        {
            emp.salary += amount;
            return emp;
        }
        public static Employee operator -(Employee emp, int amount)
        {
            emp.salary -= amount;
            return emp;
        }
        public static Employee operator *(Employee emp, int amount)
        {
            emp.salary *= amount;
            return emp;
        }
      public static bool operator<(Employee emp, int amount)
        {
            
            return emp.salary<amount; ;
        }
        public static bool operator >(Employee emp, int amount)
        {

            return emp.salary > amount;

        }
    }

    class OpOver
    {
        static void Main(string[] args)
        {
            Employee Emp = new Employee { name = "vinayak", Id = 100, salary = 10000 };
            Emp += 5000;
            Console.WriteLine(Emp.salary);
            Emp *= 5000;
            Console.WriteLine(Emp.salary);
            Emp -= 5000;
            Console.WriteLine(Emp.salary);
            Console.WriteLine(Emp > 15000);
            Console.WriteLine(Emp < 15000);
            Console.WriteLine(Environment.MachineName);
        }
    }
}
