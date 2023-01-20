using System;
using Database;
using DataLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SampleDatabaseApp.Practical_Database
{
    class DisconnectedDctor : IPatientComponent
    {
        string StrConn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        string query = "Select * from tblDoctor; select * from tblPatient";
        DataSet PatientData = new DataSet("Records");
        static SqlDataAdapter ada = null;

        public void FillData()
        {
            ada = new SqlDataAdapter(query, new SqlConnection(StrConn));
            SqlCommandBuilder builder = new SqlCommandBuilder(ada);
            ada.Fill(PatientData);
            PatientData.Tables[0].TableName = "PatientData";
            PatientData.Tables[1].TableName = "DoctorData";
        }
        public void AddPatient(Patient patient)
        {
            var newRow = PatientData.Tables[0].NewRow();
            newRow[0] = patient.PatientId;
            newRow[1] = patient.PatientName;
            newRow[2] = patient.PatientAddress;
            newRow[3] = patient.DoctorId;

            PatientData.Tables[0].Rows.Add(newRow);
            ada.Update(PatientData, "PatientData");
        }

        public void DeletePatient(int PatientId)
        {
            foreach (DataRow row in PatientData.Tables[0].Rows)
            {
                if ((int)row[0] == PatientId)
                {
                    row.Delete();
                    break;
                }
                ada.Update(PatientData, "PatientData");
            }
        }

        public List<Doctor> GetDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();
            foreach (DataRow  row in PatientData.Tables[1].Rows)
            {
                Doctor doctor = new Doctor
                {
                    DoctorId = (int)row[0],
                    DoctorName = row[1].ToString(),
                    DoctorSpec = row[2].ToString()
                };
            doctors.Add(doctor);
            }
            return doctors;
        }

        public List<Patient> GetPatients()
        {
            List<Patient> patients = new List<Patient>();
            foreach (DataRow row in PatientData.Tables[0].Rows)
            {
                Patient patient = new Patient
                {
                    PatientId = (int)row[0],
                    PatientName = row[1].ToString(),
                    PatientAddress = row[2].ToString()
                };
                patients.Add(patient);
            }
            return patients;
        }

        public void UpdatePatient(Patient patient)
        {
            foreach (DataRow row in PatientData.Tables[0].Rows)
            {
                if ((int)row[0] == patient.PatientId)
                {
                    row[1] = patient.PatientName;
                    row[2] = patient.PatientAddress;
                    row[3] = patient.DoctorId;
                }
            }
            ada.Update(PatientData, "PatientData");
        }
    }
}
