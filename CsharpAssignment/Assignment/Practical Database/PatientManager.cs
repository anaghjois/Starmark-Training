using System;
using System.Collections.Generic;
using Database;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DataLayer
{
    interface IPatientComponent
    {
        void AddPatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(int PatientId);
        List<Patient> GetPatients();
        List<Doctor> GetDoctors();
    }
    class PatientManager : IPatientComponent
    {
        private string strCon = string.Empty;

        #region Quries
        const string STRINSRT = "InsertPatient";
        const string STRUPDATE = "Update tblPatient set PatientName=@PatientName,PatientAddress=@PatientAddress,DoctorId=@DoctorID where PatientId=@PatientId";
        const string STRDELETE = "Delete from tblPatient where PatientId=@PatientId";
        const string STRPATIENTS = "Select * from tblPatient";
        const string STRDOCTORS = "Select * from tblDoctor";
        #endregion

        #region Helpers
        private void QueryHelpers(string query, SqlParameter[] parameters, CommandType type)
        {
            SqlCommand cmd = new SqlCommand(query, new SqlConnection(strCon));
            cmd.CommandType = type;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open) cmd.Connection.Close();
            }
        }

        private DataTable GetRecord(string query, SqlParameter[] parameters, CommandType type = CommandType.Text)
        {
            SqlCommand cmd = new SqlCommand(query, new SqlConnection(strCon));
            cmd.CommandType = type;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
            try
            {
                cmd.Connection.Open();
                var reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable("Records");
                dataTable.Load(reader);
                return dataTable;
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open) cmd.Connection.Close();
            }
        }
        #endregion
        public PatientManager(string connectionString)
        {
            strCon = connectionString;
        }

        #region CrudOps
        public void AddPatient(Patient patient)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PatientId", patient.PatientId));
            parameters.Add(new SqlParameter("@PatientName", patient.PatientName));
            parameters.Add(new SqlParameter("@PatientAddress", patient.PatientAddress));
            parameters.Add(new SqlParameter("@DoctorId", patient.DoctorId));

            try
            {
                QueryHelpers(STRINSRT, parameters.ToArray(), CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void DeletePatient(int PatientId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PatientId", PatientId));
            try
            {
                QueryHelpers(STRDELETE, parameters.ToArray(), CommandType.Text);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public List<Doctor> GetDoctors()
        {
            var table = GetRecord(STRDOCTORS, null);
            List<Doctor> doctors = new List<Doctor>();
            foreach (DataRow row in table.Rows)
            {
                Doctor doctor = new Doctor
                {
                    DoctorId = Convert.ToInt32(row[0]),
                    DoctorName = row[1].ToString(),
                    DoctorSpec = row[2].ToString()
                };
                doctors.Add(doctor);
            }
            return doctors;
        }
        public List<Patient> GetPatients()
        {
            var table = GetRecord(STRPATIENTS, null);
            List<Patient> patients = new List<Patient>();
            foreach (DataRow row in table.Rows)
            {
                Patient patient = new Patient
                {
                    PatientId = (int)row[0],
                    PatientName = row[1].ToString(),
                    PatientAddress = row[2].ToString(),
                    DoctorId = row.IsNull(3) ? 0 : (int)row[3]
                };
                patients.Add(patient);
            }
            return patients;
        }
        public void UpdatePatient(Patient patient)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PatientName", patient.PatientName));
            parameters.Add(new SqlParameter("@PatientAddress", patient.PatientAddress));
            parameters.Add(new SqlParameter("@PatientId", patient.PatientId));
            parameters.Add(new SqlParameter("@DoctorId", patient.DoctorId));
            try
            {
                QueryHelpers(STRUPDATE, parameters.ToArray(), CommandType.Text);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
