using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp
{
    class Utilities
    {
        internal static string Prompt(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        internal static int GetNumber(string question)
        {
            return int.Parse(Prompt(question));
        }
        internal static  long GetLong(string question)
        {
            return long.Parse(Prompt(question));
        }
    }

    /* class Employee
     {
         public int id { get; set; }
         public string name { get; set; }
         public string  address { get; set; }
         public double salary { get; set; }
     }*/
    class Accounts
    {
        public int AccNo { get; set; }
        public string Name { get; set; }
        public int Balance { get; private set; } = 5000;
        public void credit(int amount) => Balance += amount;
        public void Debit(int amount)
        {
            if (amount > Balance)
                throw new Exception("Insufficient Funds");
            Balance -= amount;
        }
    }

    class AccountManager
    {
        private Accounts[] _accounts = null;
        private int _size = 0;
        public AccountManager(int size)
        {
            _size = size;
            _accounts = new Accounts[_size];
        }
        public void  AddNewAccount(Accounts acc)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_accounts[i] == null)
                {
                    _accounts[i] = new Accounts();
                    acc.AccNo = acc.AccNo;
                    acc.Name = acc.Name;
                    _accounts[i].credit((int)acc.Balance);
                    return;
                }
            }
        }
        public  void UpdateAccounts(Accounts acc)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_accounts[i] != null && _accounts[i].AccNo == acc.AccNo)
                {
                    _accounts[i].Name = acc.Name;
                    return;
                }
            }
            throw new Exception("ACCOUNT NOT FOUND");
        }
        public void DeleteAccounts(int id)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_accounts[i] != null && _accounts[i].AccNo == id)
                {
                    _accounts[i] = null;
                    return;
                }
            }
            throw new Exception("NO ACCOUNT TO BE DELETED");
        }
        public Accounts FindAcc(int id)
        {
            foreach (Accounts acc in _accounts)
            {
             if(acc!=null&& acc.AccNo==id)
                {
                    return acc;
                }
            }
            throw new Exception("NO ACCOUNT FOUND");
        }
    }
    class ClassesObjects
    {
        static void Main(string[] args)
        {
            /* emp = new Employee();
            emp.id = 100;
            emp.name = "Harish";
            emp.address = "Shimoga"; emp.salary = 15000;

            Console.WriteLine($"name:{emp.name} empID:{emp.id}");*/
            /*
            Accounts acc = new Accounts();
            acc.AccNo = 224455;
            acc.Name = "IDRIS";
            Console.WriteLine("The balance :"+acc.Balance);
            acc.credit(15000);
            Console.WriteLine("The balance :" + acc.Balance);
            try
            {
                acc.Debit(45000);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }*/
            Console.WriteLine("Enter the acc count you want  to create");
            int count = int.Parse(Console.ReadLine());
            AccountManager mgr = new AccountManager(count);
            try
            {
                mgr.FindAcc(123);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
