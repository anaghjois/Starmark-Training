using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp
{   
    sealed class Seal
    {
        public void Run()
        {
            Console.WriteLine("Hello how are you");
        }
        
    }
     class SampleSeal
    {
        public virtual void Runs()
        {
            Console.WriteLine("Hello how are you");
        }
    }
     class SampleSeal1:SampleSeal
    {
        public override sealed void Runs()
        {
            Console.WriteLine("Hello how are you Idris ?");
        }

    }
    class sealConcept

    {
        static void Main(string[] args)
        {
            Seal seal = new Seal();
            SampleSeal sampleSeal = new SampleSeal1();
            sampleSeal.Runs();
            seal.Run();

        }
    }
}
