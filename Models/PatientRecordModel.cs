using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskProject.Models
{
    public class PatientRecordModel
    {
        public int ID { get; set; }

        public string DiseaseName { get; set; }

        public string Description { get; set; }

        public double AmountBill { get; set; }

        public DateTime TimeEntry { get; set; }
        
        public int PatientID { get; set; }
     
    }
    public class PatientRecordModelGetAll
    {
        public int ID { get; set; }

        public string DiseaseName { get; set; }

        public string Description { get; set; }

        public double AmountBill { get; set; }

        public DateTime TimeEntry { get; set; }

        public int PatientID { get; set; }

        public PatientModelWithoutRecord Patient { get; set; }
    }
}
