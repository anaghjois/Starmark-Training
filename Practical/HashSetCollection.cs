using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameworksApp.Practical
{
    class HashSetCollection
    {
        HashSet<Entity> entities = new HashSet<Entity>();
        public void AddNewCustomer(Entity cst) => entities.Add(cst);
        public HashSet<Entity> Allcustomers => entities;
    }
}
