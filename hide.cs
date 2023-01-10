using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp
{
    class hide
    {       
        class baseClass
        {
            public void baseFunc() => Console.WriteLine("Hi Hello");
        }
        class deriveClass : baseClass
        {
            public new void baseFunc() => Console.WriteLine("Bye Bye");
            public void  derivedFunc() => Console.WriteLine("Hello Good Morning");
        }
        static void Main(string[] args)
        {
            baseClass bc = new deriveClass();
            bc.baseFunc();
            if(bc is deriveClass)
            {
                deriveClass dc = (deriveClass)bc;
                dc.baseFunc();
                dc.baseFunc();
            }
            //deriveClass dc = bc as deriveClass;
           
        }   
    }
}
