using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp
{
    class Business
    {
        public virtual void MakePayment(string paymode,double amount)
        {
            if (paymode == "creditcard")
            {
                Console.WriteLine("Payment Not accepted");
            }
            else Console.WriteLine("Paymnt accepted by {1} for Rs.{0}",amount,paymode);
        }
    }
    class TechBusiness : Business
    {
        public override void MakePayment(string paymode, double amount)
        {
            if (paymode == "cheque")
            {
                Console.WriteLine("Payment is no longer accepted");
            } 
           else Console.WriteLine("Paymnt accepted by {1} for Rs.{0}", amount, paymode);

            base.MakePayment("creditcard", 5000);
        }
    }
   /* class BusinessFactory
    {
        public static Business GetObject(string arg)
        {
            if (arg.ToUpper() == "BUSINESS")
                return new Business();
            else if (arg.ToUpper() == "TECHBUSINESS")
                return new TechBusiness();
            else
                throw new Exception("This type of Business is not availabe with Us!!!");

        }*/
    
        class over
    {
        static void Main(string[] args)
        {
            Business current =new TechBusiness();
            current.MakePayment("cheque", 7000);
            TechBusiness tech = (TechBusiness)current;
            tech.MakePayment("cheque", 10000);
        }
    }
}

