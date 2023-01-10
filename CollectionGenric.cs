using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameworksApp
{
   
    class CollectionGenric
    {
        static void Main(string[] args)
        {
            //ListGenExample();
            dictionaryExample();
        }
        static Dictionary<string, string> users = new Dictionary<string, string>();

        private static void dictionaryExample()
        {
            do
            {
                Console.WriteLine("Press 1 to Sign In(Login) and 2 to Sign Up(Register)");
                var choice = Console.ReadLine();
                if (choice == "1") signUp();
                else if (choice == "2") signIn();
                else Console.WriteLine("Invalid Choice");
            } while (true);
        }

        private static void signUp()
        {
        RETRY:
            Console.WriteLine("Enter the user name");
            var uname = Console.ReadLine();
            Console.WriteLine("Enter the password");
            var pwd = Console.ReadLine();
            if (users.ContainsKey(uname))
            {
                if (users[uname] == pwd)
                {
                    Console.WriteLine("Welcome User!!!");
                }
                else
                {
                    Console.WriteLine("Password is invalid");
                    goto RETRY;
                }
            }
            else
            {
                Console.WriteLine("User does not exist");
                goto RETRY;
            }
        }

        private static void signIn()
        {
           RETRY:
            Console.WriteLine("Enter the user name");
            var uname = Console.ReadLine();
            Console.WriteLine("Enter the password");
            var pwd = Console.ReadLine();
            if (users.ContainsKey(uname))
            {
                Console.WriteLine("User Already Registered");
                goto RETRY;
            }
            users.Add(uname, pwd);
        }

        private static void ListGenExample()
        {
            List<double> vs = new List<double>();
            vs.Add(25.36);
            vs.Add(276.36);
            vs.Add(2554.36);
            vs.Add(14215.36);
            vs.Add(245425.36);
            foreach (var item in vs)
            {
                Console.WriteLine(item);
            }
        }
    }
}
