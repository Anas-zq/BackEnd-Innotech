using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskProject.Entities;

namespace TaskProject.Models
{
    public class PatientReportModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double AvgOfBill { get; set; }
        public double AvgOfBillRemovingOutliers { get; set; }
        public PatientRecordModel FifthPatientRecord { get; set; }
        public List<PatientModelWithoutRecord> ListOfPatientWithSameTwoDisease { get; set; }
        public string MonthHighVisit { get; set; }
        public bool FifthRecordExist { get; set; }
        public bool ShowArray { get; set; }
        public List<Columns> Columns { get; set; }
    }
    public class PatientReport
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double AvgOfBill { get; set; }
        public double AvgOfBillRemovingOutliers { get; set; }
        public PatientRecord FifthPatientRecord { get; set; }
        public List<Patient> ListOfPatientWithSameTwoDisease { get; set; }
        public int MonthHighVisit { get; set; }

    }
    public class Columns
    {
        public string DataField { get; set; }
        public string Text { get; set; }
    }
}
