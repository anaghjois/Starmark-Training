using System;
using DataLayer;
using UtilitiesLayer;
using System.Collections.Generic;
using SampleFrameworksApp.Practical;

namespace DataLayer
{
    class ListCollection : ICustomer
    {
        public ListCollection()
        {
            Console.WriteLine("List is being Used");
        }
        List<Entity> entities = new List<Entity>();
        public void AddCustomer(Entity cst) => entities.Add(cst);

        public void DeleteCustomer(int id)
        {
            foreach (var cst in entities)
            {
                if (cst.CustomerId == id)
                {
                    entities.Remove(cst);
                    return;
                }
            }
            throw new Exception("Customer not found");
        }

        public Entity[] GetAllCustomer() => entities.ToArray();

        public void UpdateCustomer(Entity ent)
        {
            foreach (var cst in entities)
            {
                if (cst.CustomerId == ent.CustomerId)
                {
                    cst.copy(ent);
                    return;
                }
            }
            throw new Exception("Customer not found to update");
        }
    }
}
