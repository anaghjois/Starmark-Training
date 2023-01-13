using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
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
    }

    enum Factors
    {
        EXTERNAL_FACTOR = 1, INTERNAL_FACTOR
    }
    enum Severity
    {
        HIGH = 1, MEDIUM, LOW
    }
    enum Methods
    {
        AddDisease = 1, AddSymptom, CheckPatient
    }
    class UserInterface
    {

        public const string menu = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~MEDICAL RESEARCH APPLICATION~~~~~~~~~~~~~~~~~~~\nTO ADD NEW DISEASE------------------------>PRESS 1\nTO ADD NEW SYMPTOM---------------->PRESS 2\nTO CHECK PATIENT----------------->PRESS 3\nPS: ANY OTHER KEY IS CONSIDERED AS EXIT.....................................";
        private static DiseaseManager disease;
        public static Symptoms sym = new Symptoms();
        public static void run()
        {
            int size = Utilities.GetNumber("Enter the number of Diseases you want to Add");
            disease = new DiseaseManager(size);
            bool processing = true;
            do
            {
                Methods method = (Methods)Utilities.GetNumber(menu);
                processing = processMenu(method);
            } while (processing);
            Console.WriteLine("Thanks for Using our Application!!!");
        }

        private static bool processMenu(Methods method)
        {
            switch (method)
            {
                case Methods.AddDisease:
                    AddingDisease();
                    break;
                case Methods.AddSymptom:
                    AddingSymptom();
                    break;
                case Methods.CheckPatient:
                    CheckingPatient();
                    break;
                default:
                    break;
            }
            return true;
        }

        private static void CheckingPatient()
        {
            disease.checkPatient(sym);
        }

        private static void AddingSymptom()
        {
            string DiseaseName = Utilities.Prompt("Enter the disease Name").ToUpper();
            string severness = Utilities.Prompt("Enter the severity i.e LOW,HIGH,MEDIUM").ToUpper();
            Severity severity = (Severity)Enum.Parse(typeof(Severity), severness);
            string cause = Utilities.Prompt("Enter the cause of disease i.e External_Factor or Internal_Factor").ToUpper();
            Factors factor = (Factors)Enum.Parse(typeof(Factors), cause);
            string SymptomName = Utilities.Prompt("Enter the symptoms").ToUpper();
            string Description = Utilities.Prompt("Enter the description(less than 30 characters)").ToUpper();
            sym = new Symptoms { Description = Description, DiseaseName = DiseaseName, Severity = severity, Cause = factor, SymptomName = SymptomName };
            disease.AddSymptom(sym);
            Utilities.Prompt("Press Enter to clear");
            Console.Clear();
        }
        private static void AddingDisease()
        {
            string DiseaseName = Utilities.Prompt("Enter the disease Name").ToUpper();
            string severness = Utilities.Prompt("Enter the severity i.e LOW,HIGH,MEDIUM").ToUpper();
            Severity severity = (Severity)Enum.Parse(typeof(Severity), severness);
            string cause = Utilities.Prompt("Enter the cause of disease i.e External_Factor or Internal_Factor").ToUpper();
            Factors factor = (Factors)Enum.Parse(typeof(Factors), cause);
            string Description = Utilities.Prompt("Enter the description(less than 30 characters)").ToUpper();
            Disease dise = new Disease { Description = Description, DiseaseName = DiseaseName, Severity = severity, Cause = factor };
            disease.AddDisease(dise);
            Utilities.Prompt("Press Enter to clear");
            Console.Clear();
        }
    }
    class Disease
    {
        public string DiseaseName { get; set; }
        public Severity Severity { get; set; }
        public Factors Cause { get; set; }
        /// <summary>
        /// <c>Description</c> It is a Disease description should not be less than 30 Characters
        /// </summary>
        public string Description { get; set; }
    }
    class Symptoms : Disease
    {
        public String SymptomName { get; set; }
    }

    class DiseaseManager
    {
        private Disease[] _diseases = null;
        private Symptoms[] _symptoms = null;
        private readonly int _size;
        public DiseaseManager(int size)
        {
            _size = size;
            _diseases = new Disease[_size];
            _symptoms = new Symptoms[_size];
        }
        public void AddDisease(Disease dis)
        {
            for (int i = 0; i < _diseases.Length; i++)
            {
                if (_diseases[i] == null)
                {
                    _diseases[i] = new Disease { DiseaseName = dis.DiseaseName, Severity = dis.Severity, Cause = dis.Cause, Description = dis.Description };
                    Console.WriteLine("Disease Added");
                    return;
                }
            }
        }
        public void AddSymptom(Symptoms sym)
        {
            for (int i = 0; i < _symptoms.Length; i++)
            {
                if (_diseases[i].DiseaseName == sym.DiseaseName && _diseases[i].Severity == sym.Severity)
                {
                    _symptoms[i] = new Symptoms { SymptomName = sym.SymptomName, Description = sym.Description, DiseaseName = sym.DiseaseName, Severity = sym.Severity, Cause = sym.Cause };
                    Console.WriteLine("Symptom");
                    return;
                }
                else throw new Exception("Disease Not found");
            }
        }
        public void checkPatient(Symptoms sym)
        {
            string patientName = Utilities.Prompt("Enter the patient name").ToUpper(); ;
            string symptom = Utilities.Prompt("Enter the symptoms of patient").ToUpper();
            for (int i = 0; i < _symptoms.Length; i++)
            {
                if (symptom.Contains(sym.SymptomName))
                {
                    string disease = sym.DiseaseName;
                    Console.WriteLine("The Disease that patient might has are" + disease);
                    return;
                }
                else throw new Exception("Disease not found");
            }
        }
    }
    class Menu
    {
        static void Main(string[] args)
        {
            UserInterface.run();
        }
    }
}
