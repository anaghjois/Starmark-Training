using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameworksApp
{
    
    class CollectionsEx
    {
        static void Main(string[] args)
        {
            //ArrayListExample();
            // HashTableExample();
            HashSetExample();
        }

        private static void HashSetExample()
        {
            HashSet<string> vs = new HashSet<string>();
            vs.Add("Mallika");
            if (!vs.Add("Mallika"))
            {
                Console.WriteLine("Already exist");
            }
            vs.Add("Raspuri");
            Console.WriteLine(vs.Count());
            foreach (var item in vs)
            {
                Console.WriteLine(item);
            }
        }

        private static void HashTableExample()
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("Anagha", 1509);
            hashtable["Idris"] = 1997;
            Console.WriteLine(hashtable["Idris"]);
            foreach (DictionaryEntry item in hashtable)
            {
                Console.WriteLine(item.Key+":"+item.Value);
            }
        }
        private static void ArrayListExample()
        {
            ArrayList array = new ArrayList();
            array.Add(123);
            array.Add("Idris");
            array.Add(96587432);
            array.Insert(2, "Malli");
            array.Remove(123);
            foreach (var item in array)
            {
                Console.WriteLine("The values are "+item);
            }
        }
    }
}
