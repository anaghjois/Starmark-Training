using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp
{
    class Base
    {
        public Base()
        {
            Console.WriteLine("hello from Base");
        }
        public Base(string name) : this()
        {
            Console.WriteLine("hello from Base Name");
        }
    }
    class Derived:Base
    {
        public Derived(string name):base(name)
        {
            Console.WriteLine("Hi from Sub Base");
        }
    }
    class chaining
    {
        static void Main(string[] args)
        {
           Derived der = new Derived("hi");
            //Base b = new Base();
        }

    }
}
