using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp
{       
    class Bank
    {
        public int Account { get; set; }
        public  string AccountName { get; set; }
        public int Balance { get; protected set; } = 5500;
    }
    class SBAccount : Bank
    {
        public void credit(int amount) => Balance += amount;
        public void debit(int amount) => Balance -= amount;
    }
    class RdAccount : Bank
    {
        int amount = 5000;
        public void MakePayment()
        {
            Console.WriteLine($"Payment is Rs.{amount} is done");
            Balance += amount;
        }
    }
    class Inheri
    {
        static void Main(string[] args)
        {
            SBAccount Acc = new SBAccount { AccountName = "Vinayak", Account = 22554 };
            Acc.credit(10000);
            Acc.debit(15000);
            Console.WriteLine("The Balance : " + Acc.Balance);
            RdAccount rd = new RdAccount();
            Console.WriteLine(rd.AccountName);
            rd.MakePayment();
            Console.WriteLine("The Balance : " + rd.Balance);
        }
    }
}
