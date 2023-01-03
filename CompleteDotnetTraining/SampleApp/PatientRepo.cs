using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace SampleApp
{
    class Patient
    {
        public int PatientId { get; set; }
        public String PatientName { get; set; }
        public long PatientMobileNumber { get; set; }
        public string PatientAddress { get; set; }
        public string Status { get; set; }
    }

    class PatientManager
    {
        private Patient[] _patient = new Patient[100];

        //Adding new patient
        public void AddPatient(Patient pat)
        {
            for (int i = 0; i < _patient.Length; i++)
            {
                if (_patient[i] == null)
                {
                    _patient[i] = new Patient() { PatientId = pat.PatientId, PatientName = pat.PatientName, PatientAddress = pat.PatientAddress, PatientMobileNumber = pat.PatientMobileNumber, Status = pat.Status };
                    Console.WriteLine("Patient Added");
                    return;
                }
            }
        }
        public void UpdatePatientStatus(Patient pat)
        {
            for (int i = 0; i < _patient.Length; i++)
            {
                if (_patient[i] != null && _patient[i].PatientId == pat.PatientId)
                {
                    _patient[i].Status = pat.Status;
                    return;
                }
            }
            throw new Exception("No patient Data Available");
        }
        public void ShowAllPatients()
        {
            if (_patient.Length != 0)
            {
                for (int i = 0; i < _patient.Length; i++)
                {
                    Console.WriteLine($"Id:{_patient[i].PatientId}\n Name:{_patient[i].PatientName}\n Address:{_patient[i].PatientAddress}\n Phone:{_patient[i].PatientMobileNumber}\n Status:{_patient[i].Status}");
                }
            }
            else
            {
                Console.WriteLine("No pAtient Available");
            }
         }
            public Patient ShowPatientById(int id)
        {
            foreach (Patient pat in _patient)
            {
                if (pat != null && pat.PatientId == id)
                    return pat;
            }
            throw new Exception("No Patients available;");
        }
    }
    class Hospital
    {
        public static PatientManager ptm = new PatientManager();
        public static void DisplayMenu(String file)
        {
            bool process = true;
            string menu = File.ReadAllText(file);
            do
            {
                int choice = Utilities.GetNumber(menu);
                process = procesMenu(choice);
            } while (process);
        }
        private static bool procesMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                    addingPatientHeper();
                    break;
                case 2:
                    updatingPatientHelper();
                    break;
                case 3:
                     showPatientsHelper();
                    break;
                case 4:
                    findPatientHelper();
                    break;
                default:
                    return false;
            }
            return true;
        }

        private static void showPatientsHelper()
        {
             ptm.ShowAllPatients();
            Utilities.Prompt("Press Enter to clear the Screen");
            Console.Clear();
        }

        private static void findPatientHelper()
        {
            int id = Utilities.GetNumber("Enter the ID of the Patient to Find");
            try
            {
                Patient pat = ptm.ShowPatientById(id);
                Console.WriteLine("The patient details are");
                string details = $"Patient Name : {pat.PatientName}\n Patient Number :{pat.PatientMobileNumber}\n Patient Address : {pat.PatientAddress}\n Patient Status: {pat.Status}";
                Console.WriteLine(details);
                Utilities.Prompt("Press Enter to clear the Screen");
                Console.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void updatingPatientHelper()
        {
            int id = Utilities.GetNumber("Enter the patient ID");
            string status = Utilities.Prompt("Update Patient Status ");
            Patient pat = new Patient();
            pat.PatientId = id;
            pat.Status = status;
            ptm.UpdatePatientStatus(pat);
            Utilities.Prompt("Press Enter to clear the Screen");
            Console.Clear();
        }

        private static void addingPatientHeper()
        {
            int id = Utilities.GetNumber("Enter the patient Id");
            string name = Utilities.Prompt("Enter the patient name");
            long phnno = Utilities.GetLong("Enter the patient mobile number");
            string address = Utilities.Prompt("Enter the Patient Address");
            string status = Utilities.Prompt("Enter Patient is Dead , Alive or Discharged ");
            Patient pat = new Patient();
            pat.PatientId = id;
            pat.PatientName = name;
            pat.PatientMobileNumber = phnno;
            pat.Status = status;
            pat.PatientAddress = address;
            ptm.AddPatient(pat);
            Utilities.Prompt("Press Enter to clear");
            Console.Clear();
        }
    }
        class PatientRepo
        {
            static void Main(string[] args)
            {
                Hospital.DisplayMenu(args[0]);
            }

        }
}
