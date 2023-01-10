using System;

namespace Assignment
{
    class DynamicArray
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of an array");
            int Size = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the common type for the data types");
            string TypeName = Console.ReadLine();
            Type type = Type.GetType(TypeName, true, true);
            Array myArray = Array.CreateInstance(type, Size);
            for (int i = 0; i < Size; i++)
            {
                Console.WriteLine($"Enter the value of the {type.Name}");
                string enteredValue = Console.ReadLine();
                object convertedValue = Convert.ChangeType(enteredValue, type);
                myArray.SetValue(convertedValue, i);
            }
            Console.WriteLine("All Values are");
            foreach  (object values in myArray)
            {
                Console.WriteLine(values);
            }
        }
    }
}
