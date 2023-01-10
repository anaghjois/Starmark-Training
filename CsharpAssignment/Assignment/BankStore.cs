using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    enum Accounts { SB = 1, FD, RD }
    abstract class Account
    {
        public int AccountNo { get; set; }
        public int Balance { get; private set; } = 5000;
        public string Name { get; set; }
        public void credit(int amount) => Balance += amount;
        public void debit(int amount)
        {
            if (amount > Balance) {
                throw new Exception("Insufficient Funds");
            }
            Balance -= amount;
        }
        public abstract void CalculateInterest();
    }
    class SBAccunt : Account
    {
        public override void CalculateInterest()
        {
            var principal = Balance;
            var time = 0.25;
            var rate = 0.05;
            var interest = principal * time * rate;
            credit((int)interest);
        }
    }
    class FDAccount : Account
    {
        public override void CalculateInterest()
        {
            var principal = Balance;
            var rate = 0.1;
            var time = 12;
            var compound = 4;
            var interest = Math.Pow(principal * (1 + (rate / compound)), (compound * time));
            credit((int)interest);
        }
    }
    class RDAccont : Account
    {
        public override void CalculateInterest()
        {
            var principal = Balance;
            var install = 500;
            var rate = 0.08;
            var time = 0.25;
            var interest = install * ((1 + rate) * time - 1) / 1 - (1 + rate) * (-0.333);
            credit((int)interest);
        }
    }
    class AccountFactory
    {
        public static Account getAccount(string args)
        {
            if (args.ToUpper() == "SB")
                return new SBAccunt();
            else if (args.ToUpper() == "FD")
                return new FDAccount();
            else if (args.ToUpper() == "RD")
                return new RDAccont();
            else
                throw new Exception("Account not found");
        }
    }
    class UIlayer
    {
        public static void Start()
        {
            bool process = true;
            do
            {
                Console.WriteLine("Enter the type of account you want ?  (SB , FD, RD)");
                string ch = Console.ReadLine().ToUpper();
                Accounts choice = (Accounts)Enum.Parse(typeof(Accounts), ch);
                switch (choice)
                {
                    case Accounts.SB:SBAccountHelper(ch);
                        break;
                    case Accounts.FD:FDAccountHelper(ch);
                      
                        break;
                    case Accounts.RD:RDAccountHelper(ch);
                        break;
                    default:
                        Console.WriteLine("Enter the valid Account");
                        break;
                }
            } while (process);
            }

        private static void RDAccountHelper(string ch)
        {
            Account acc = AccountFactory.getAccount(ch);
            Console.WriteLine("Enter Account name");
            acc.Name = Console.ReadLine();
            Console.WriteLine("Enter Account Number");
            acc.AccountNo =int.Parse(Console.ReadLine());
            acc.CalculateInterest();
            Console.WriteLine("The Acc No :" + acc.AccountNo);
            Console.WriteLine("The Name :" + acc.Name);
            Console.WriteLine("The Balance is : " + acc.Balance);
        }

        private static void FDAccountHelper(string ch)
        {
            Account acc = AccountFactory.getAccount(ch);
            Console.WriteLine("Enter Account name");
            acc.Name = Console.ReadLine();
            Console.WriteLine("Enter Account Number");
            acc.AccountNo = int.Parse(Console.ReadLine());
            acc.CalculateInterest();
            Console.WriteLine("The Acc No :" + acc.AccountNo);
            Console.WriteLine("The Name :" + acc.Name);
            Console.WriteLine("The Balance is : " + acc.Balance);
        }

        private static void SBAccountHelper(string ch)
        {
            Account acc = AccountFactory.getAccount(ch);
            Console.WriteLine("Enter Account name");
            acc.Name = Console.ReadLine();
            Console.WriteLine("Enter Account Number");
            acc.AccountNo = int.Parse(Console.ReadLine());
            acc.CalculateInterest();
            Console.WriteLine("The Acc No :" + acc.AccountNo);
            Console.WriteLine("The Name :" + acc.Name);
            Console.WriteLine("The Balance is : " + acc.Balance);
        }
    }
        class BankStore
        {
            static void Main(string[] args)
            {
            UIlayer.Start();
         
            }
        }
    }

