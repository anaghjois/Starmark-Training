using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SampleFrameworksApp.FileHandling
{
    [Serializable]
   public  class Employee
    {
        public int EmpId { get; set; }
        public string  EmpName { get; set; }
        public string EmpAddress { get; set; }
        public override string ToString()
        {
            return $"{EmpName} from {EmpAddress}";
        }
    }
    class SerializationDemo
    {
        static void Main(string[] args)
        {
            //serializeExample();
            //DeserializeExample();
            //xmlSerialize();
            //xmlDeserialize();
            soapXmlSerializer();
            soapXmlDeserilizer();
        }

        private static void soapXmlDeserilizer()
        {
            Employee emp = null;
            FileStream fs = new FileStream("EmpSoap.xml", FileMode.Open, FileAccess.Read);
            SoapFormatter fm = new SoapFormatter();
            emp = fm.Deserialize(fs) as Employee;
            fs.Close();
            Console.WriteLine(emp);
        }

        private static void soapXmlSerializer()
        {
            Employee emp = new Employee
            {
                EmpId = 111,
                EmpAddress = "Bangalore",
                EmpName = "Phaniraj"
            };
            FileStream fs = new FileStream("EmpSoap.xml", FileMode.OpenOrCreate, FileAccess.Write);
            SoapFormatter formatter = new SoapFormatter();
            formatter.Serialize(fs, emp);
            fs.Close();//Close the stream...
        }

        private static void xmlDeserialize()
        {
            Employee emp = null;
            FileStream fs = new FileStream("Emp.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer fm = new XmlSerializer(typeof(Employee));
            emp = fm.Deserialize(fs) as Employee;
            fs.Close();
            Console.WriteLine(emp);
        }

        private static void xmlSerialize()
        {
            Employee emp = new Employee
            {
                EmpId = 420,
                EmpAddress = "Arsikere",
                EmpName = "Idris"
            };
            FileStream fileStream = new FileStream("Emp.xml", FileMode.OpenOrCreate, FileAccess.Write);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));
            xmlSerializer.Serialize(fileStream, emp);
            fileStream.Close();
        }

        private static void DeserializeExample()
        {
            Employee employee = null;
            FileStream fileStream = new FileStream("emp.Bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            employee=binaryFormatter.Deserialize(fileStream) as Employee;
            fileStream.Close();
            Console.WriteLine(employee);
        }

        private static void serializeExample()
        {
            Employee employee = new Employee { EmpId = 123, EmpName = "Idris", EmpAddress = "arsikere" };
            FileStream fileStream = new FileStream("emp.Bin", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, employee);
            fileStream.Close();
        }
    }
}
