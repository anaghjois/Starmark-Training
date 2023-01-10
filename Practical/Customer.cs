using System;
using SampleFrameworksApp.Practical;
using System.Collections;
using UtilitiesLayer;


namespace DataLayer
{
    interface ICustomer
    {
        void AddCustomer(Entity cst);
        void DeleteCustomer(int id);
        void UpdateCustomer(Entity cst);
        Entity[] GetAllCustomer();

    }
    class CustomerRepo : ICustomer
    {
        public CustomerRepo()
        {
            Console.WriteLine("Array List being Used");
        }
        private ArrayList customerlist = new ArrayList();
        public void AddCustomer(Entity cst)
        {
            customerlist.Add(cst);
        }

        public void DeleteCustomer(int id)
        {
            foreach (var cst in customerlist)
            {
                if (cst is Entity)
                {
                    var unBoxed = cst as Entity;
                    if (unBoxed.CustomerId == id)
                    {
                        customerlist.Remove(unBoxed);
                        return;
                    }
                }
            }
            throw new Exception("customer not found");
        }

        public Entity[] GetAllCustomer()
        {
            Entity[] array = new Entity[customerlist.Count];
            for (int i = 0; i < customerlist.Count; i++)
            {
                array[i] = customerlist[i] as Entity;
            }
            return array;
        }

        public void UpdateCustomer(Entity customer)
        {
            foreach (var cst in customerlist)
            {
                if (cst is Entity)
                {
                    var UnBoxed = cst as Entity;
                    if (UnBoxed.CustomerId ==customer.CustomerId )
                    {
                        UnBoxed.CustomerAddress = customer.CustomerAddress;
                        UnBoxed.CustomerName = customer.CustomerName;
                        UnBoxed.BillAmount = customer.BillAmount;
                        return;
                    }
                }
            }
            throw new Exception("Customer detail not found");
        }
    }
}

