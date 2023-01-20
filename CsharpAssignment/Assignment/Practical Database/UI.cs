using System;
using System.Collections.Generic;
using DataLayer;
using Database;
using System.Text;
using System.Data.SqlClient;
using Assessment;
using System.Threading.Tasks;
using System.Configuration;

namespace SampleDatabaseApp.Practical_Database
{
    class UI
    {
        static string ConStr = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        public static PatientManager manager = null;
    internal static void DisplayMenu()
        {
            manager = new PatientManager(ConStr);
            bool Processing = true;
            const string menu = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~PATIENT MANAGER SOFTWARE~~~~~~~~~~~~~~~~~~\nTO ADD NEW PATIENT-------------->PRESS 1\nTO UPDATE EXISTING PATIENT------>PRESS 2\nTO GET ALL PATIENT----------------->PRESS 3\nTO DELETE PATIENT--------------->PRESS 4\nTO GET ALL DOCTORS--------------->PRESS 5\nPS: ANY OTHER KEY IS CONSIDERED AS EXIT.....................................";
            do
            {
                int choice = Utilities.GetNumber(menu);
                Processing = processMenu(choice);

            } while (Processing);
            Console.WriteLine("Thnks For Using Our Application");
        }
            private static bool processMenu(int choice)
            {
            switch (choice)
            {
                case 1:addPatientHelper();
                    break;
                case 2:updatePatientHelper();
                    break;
                case 3:getPatients();
                    break;
                case 4:deletePatient();
                    break;
                case 5:getDoctors();
                    break;
                default:
                    return false;
            }
            return true;
        }

        private static void getDoctors()
        {
            var data = manager.GetDoctors();
            foreach (var doctor in data)
            {
                Console.WriteLine("Doctor Id : "+doctor.DoctorId);
                Console.WriteLine("Doctor Name : "+doctor.DoctorName);
                Console.WriteLine("Doctor Specialization : "+doctor.DoctorSpec);
            }
        }

        private static void deletePatient()
        {
            manager.DeletePatient(Utilities.GetNumber("Enter the Id to delete"));
        }

        private static void getPatients()
        {
            var data = manager.GetPatients();
            foreach (var patient in data)
            {
                Console.WriteLine("Patient Id : "+patient.PatientId);
                Console.WriteLine("Patient Name  : "+patient.PatientName);
                Console.WriteLine("Patient Address : "+patient.PatientAddress);
                Console.WriteLine("Doctor Id : "+patient.DoctorId);
            }
        }

        private static void updatePatientHelper()
        {
            var data = manager.GetDoctors();
            int PID = Utilities.GetNumber("Enter the Patient ID :");
            string PatientName = Utilities.Prompt("Enter the Name of the Patient");
            string PatientAddress = Utilities.Prompt("Enter the Address : ");
            Console.WriteLine("The Specialist Types Available are");
            foreach (var item in data)
            {
                Console.WriteLine(item.DoctorSpec);
            }
                var DoctorID = data.Find(e => e.DoctorSpec == Utilities.Prompt("Enter the specialist Name")).DoctorId;
                manager.UpdatePatient(new Patient
                {
                    PatientId=PID,
                    PatientName = PatientName,
                    PatientAddress = PatientAddress,
                    DoctorId = DoctorID
                });
         }
        
        private static void addPatientHelper()
        {
            var specilistData = manager.GetDoctors();
            string Pname = Utilities.Prompt("Enter the Patient Name : ");
            string Paddress = Utilities.Prompt("Enter the Patient Address");
            Console.WriteLine("The Specialist Doctors Available are : ");
            foreach (var item in specilistData)
            {
                Console.WriteLine(item.DoctorSpec);
            }
            int DoctorID = specilistData.Find((e)=> e.DoctorSpec==Utilities.Prompt("enter Specilist Name: ")).DoctorId;
            manager.AddPatient(new Patient
                {
                    PatientName = Pname,
                    PatientAddress = Paddress,
                    DoctorId = DoctorID
                });
            }
        }
    
    class MainClass
    {
        static void Main(string[] args)
        {
            UI.DisplayMenu();
        }
      
    }
}

    

