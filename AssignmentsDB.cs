using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Database;
using System.Data.SqlClient;
using System.IO;
using Assessment;


namespace SampleDatabaseApp
{
    class AssignmentsDB
    {
      static  string StrCon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        static void Main(string[] args)
        {

            // InsertData();
            //DeleteData();
            // EpmDeptJoin();
            //readCsv();
            //findEmp();
            // DBtoList();
            // disconnectedFind();
            InsertStoredProc();

        }

        private static void InsertStoredProc()
        {
            string query = "InsertEmployee";
            int empId = 0;
            SqlCommand command = new SqlCommand(query, new SqlConnection(StrCon));
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@empName", Utilities.Prompt("enter emp Name" ));
            command.Parameters.AddWithValue("@empAddress", Utilities.Prompt("enter emp Address"));
            command.Parameters.AddWithValue("@empSalary", Utilities.GetNumber("enter emp Salary"));
            command.Parameters.AddWithValue("@deptId", Utilities.GetNumber("enter emp Dept Id"));
            command.Parameters.AddWithValue("@empId", empId);
            command.Parameters.AddWithValue("@mgrId", Utilities.GetNumber("enter emp Manager Id"));
            command.Parameters[4].Direction = ParameterDirection.Output;
            try
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
                empId = Convert.ToInt32(command.Parameters[4].Value);
                 Console.WriteLine("EmpId of newly added Employee : "+empId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                command.Connection.Close();
            }
        }

        private static void disconnectedFind()
        {
            string query = "select * from tblEmployee";
            SqlDataAdapter ada = new SqlDataAdapter(query, new SqlConnection(StrCon));
            SqlCommandBuilder builder = new SqlCommandBuilder(ada);
            DataSet EmpData = new DataSet("Empdata");
            ada.Fill(EmpData);
            string name = Utilities.Prompt("Enter the employee name to search");
            foreach (DataRow row in EmpData.Tables[0].Rows)
            {
                if(row[1].ToString()==name)
                {
                    Console.WriteLine($"Emp Id : {row["empId"]}\n EmpName : {row["empName"]}");
                }
            }
        }

        private static void DBtoList()
        {
            string query = "select * from tblPatient";
            SqlCommand command = new SqlCommand(query, new SqlConnection(StrCon));
            try
            {
                command.Connection.Open();
                var table = command.ExecuteReader();
                DataTable dataTable = new DataTable("Record");
                dataTable.Load(table);
                List<Patient> data = new List<Patient>();
                foreach(DataRow row in dataTable.Rows)
                {
                    Patient patient = new Patient
                    {
                        PatientId = (int)row[0],
                        PatientName = row[1].ToString(),
                        PatientAddress = row[2].ToString(),
                        DoctorId = (int)row[3]
                    };
                    data.Add(patient);
                }
                foreach (var item in data)
                {
                    Console.WriteLine($"Patient Name : {item.PatientId}\n Patient Address : {item.PatientId}");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void findEmp()
        {
            string query = $"select * from tblEmployee where empname='{Utilities.Prompt("Enter the employee name")}'";
            SqlCommand sqlCommand = new SqlCommand(query, new SqlConnection(StrCon));
            try
            {
                sqlCommand.Connection.Open();
                var reader=sqlCommand.ExecuteReader();
                while (reader.Read())
                {
            
                        Console.WriteLine($"EmpName : '{reader[1]}' - EmpAddress : '{reader[2]}'");
                
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (sqlCommand.Connection.State == ConnectionState.Open) sqlCommand.Connection.Close();
            }
        }

        private static void readCsv()
        {
            string fileName = "D:/AnaghaJoisTraining/DotNetTraining/CompleteDotnetTraining/SampleFrameworksApp/FileHandling/RandomData.csv";
            string[] split= { };
            var allLines = File.ReadAllLines(fileName);
            foreach (var lines in allLines)
            {
             split = lines.Split(',');
            List<string> RandomData = new List<string>(split);
            foreach (var item in RandomData)
            {
                Console.WriteLine(item);
            }
            }
        }

        private static void EpmDeptJoin()
        {
            string query = "select Emp.EmpName,Dept.DeptName from tblEmployee Emp,tblDept Dept where Emp.DeptId=Dept.DeptId";
            SqlCommand command = new SqlCommand(query, new SqlConnection(StrCon));
            try
            {
                command.Connection.Open();
               var reader= command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["EmpName"]}-{reader["deptName"]}");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                
            }
        }

        private static void DeleteData()
        {
            int id = Utilities.GetNumber("Enter the Id to delete");
            string query = $"delete from tblEmployee where empId='{id}'";
            SqlCommand command = new SqlCommand(query, new SqlConnection(StrCon));
            try
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (command.Connection.State == ConnectionState.Open) command.Connection.Close();
            }
        }

        private static void InsertData()
        {
            string name = Utilities.Prompt("Enter the Name of Employee");
            string Address = Utilities.Prompt("Enter the patient Address");
            int salary = Utilities.GetNumber("Enter the salary");
            int deptId = Utilities.GetNumber("Enter the deptiId");
            int mgrId = Utilities.GetNumber("Enter the MgrId");
            string query = $"insert into tblEmployee values( '{name}','{Address}','{salary}','{deptId}','{mgrId}')";
            SqlCommand command = new SqlCommand(query, new SqlConnection(StrCon));
            try
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                command.Connection.Close();
            }
        }
    }
}
