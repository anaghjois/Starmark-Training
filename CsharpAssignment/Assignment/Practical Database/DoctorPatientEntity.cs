using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    class Doctor
    {
        public int  DoctorId { get; set; }
        public string  DoctorName { get; set; }
        public string DoctorSpec { get; set; }
    }
    class Patient
    {
        public int PatientId { get; set; }
        public string  PatientName { get; set; }
        public string PatientAddress { get; set; }
        public int DoctorId { get; set; }
    }
}
