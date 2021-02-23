using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskProject.Models
{
    public class PatientModel
    {
        public int ID { get; set; }

        public int OfficialID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string DateOfBirthAsString { get; set; }

        public List<PatientRecordModel> PatientRecords { get; set; }
    }
    public class PatientModelWithoutRecord
    {
        public int ID { get; set; }

        public int OfficialID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string DateOfBirthAsString { get; set; }
    }
}
