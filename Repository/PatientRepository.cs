using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskProject.Entities;
using TaskProject.Models;

namespace TaskProject.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientContext _context;

        public PatientRepository(PatientContext context)
        {
            _context = context;
        }
        public async Task<List<Patient>> GetAllPatients()
        {
            var Patients = await _context.Patients.ToListAsync();
            return Patients;
        }
        public async Task<List<PatientListModel>> GetAllPatientsWithTimeEntry()
        {
            var Patients = await _context.Patients.Include(e => e.PatientRecords)
                .Select(e => new PatientListModel { 
                ID = e.ID ,
                DateOfBirth = e.DateOfBirth.ToString("yyyy/MM/dd"),
                Name = e.Name , 
                Email = e.Email,
                TimeEntry = (e.PatientRecords.Count == 0 )? (DateTime?)null : e.PatientRecords.Max(e => e.TimeEntry)

                }).ToListAsync();
            return Patients;
        }

        public async Task<PatientReport> GetReportForPatientByID(int id)
        {
            #region Get Patients with at least the same two disease
            List<String> DiseaseNames = await _context.PatientRecords.Where(e => e.PatientID == id).Select(e => e.DiseaseName).ToListAsync();
            List<double> Bills = await _context.PatientRecords.Where(e => e.PatientID == id).OrderBy(e=>e.AmountBill).Select(e => e.AmountBill).ToListAsync();
            var ListOfPatientWithSameTwoDisease = new List<Patient>();
            int count = 0;
            string diseaseName = "";
            var patients = await _context.Patients.Include(e => e.PatientRecords).ToListAsync();
            var patientswithoutThis = patients.Where(e => e.ID != id).ToList();
            foreach (var patient in patientswithoutThis)
            {
                count = 0;
                foreach (var patientRecord in patient.PatientRecords)
                {
                    if (DiseaseNames.Contains(patientRecord.DiseaseName) && !patientRecord.DiseaseName.Equals(diseaseName))
                    {
                        count++;
                        diseaseName = patientRecord.DiseaseName;
                    }
                }
                if (count >= 2) ListOfPatientWithSameTwoDisease.Add(patient);
            }
            #endregion
            var grouped = (from p in _context.PatientRecords where p.PatientID  == id
                           group p by new { month = p.TimeEntry.Month } into d
                           select new { d.Key.month , count = d.Count() }).OrderByDescending(g => g.count);

            var groupbyDatePatients = await grouped.ToListAsync();
            var PatientReport = patients.Where(e => e.ID == id).Select(e => new PatientReport
            {
                Name = e.Name,
                Age = (DateTime.Now.DayOfYear < e.DateOfBirth.DayOfYear) ? (DateTime.Now.Year - e.DateOfBirth.Year) - 1 : (DateTime.Now.Year - e.DateOfBirth.Year),
                AvgOfBill = (e.PatientRecords.Count != 0 )? e.PatientRecords.Sum(e => e.AmountBill) / e.PatientRecords.Count : 0,
                AvgOfBillRemovingOutliers = (Bills.Count > 0)? calculateAvgOutliesrs(Bills) : 0,
                FifthPatientRecord = (e.PatientRecords.Count >= 5) ? e.PatientRecords.Skip(4).Take(1).FirstOrDefault() : null,
                ListOfPatientWithSameTwoDisease = ListOfPatientWithSameTwoDisease,
                MonthHighVisit = (groupbyDatePatients.Count>0)?   groupbyDatePatients.Select(e => e.month).FirstOrDefault() : 0,
                
            }).FirstOrDefault();
            return PatientReport;

        }
        public async Task<Patient> GetPatientByID(int id)
        {
            var Patient = await _context.Patients.Where(e => e.ID == id).Include(e=>e.PatientRecords)
                                            .FirstOrDefaultAsync();
            return Patient;

        }

        public async Task<Patient> Add(Patient Patient)
        {
            _context.Add(Patient);
            await _context.SaveChangesAsync();
            return Patient;
        }

        public async Task<bool> Update(Patient Patient)
        {
            _context.Update(Patient);
            var success = await _context.SaveChangesAsync();
            if (success == 0)
                return false;
            return true;
        }
        public async Task<bool> DeleteByID(int id)
        {
            var Patient = await GetPatientByID(id);
            _context.Remove(Patient);
            var success = await _context.SaveChangesAsync();
            if (success == 0)
                return false;
            return true;
        }

        private double calculateAvgOutliesrs(List<double> bills)
        {
            var count = bills.Count;
            int Q1Index = (int)Math.Floor(0.25 * count);
            var Q1Value = (Q1Index % 2 == 0) ? (bills[Q1Index] + bills[Q1Index]) / 2 : bills[Q1Index];
            int Q3Index = (int)Math.Floor(0.75 * count);
            var Q3Value = (Q3Index % 2 == 0) ? (bills[Q3Index] + bills[Q3Index]) / 2 : bills[Q3Index];
            var IQR = (Q3Value - Q1Value) *1.5;
            var minOutlier = Q1Value - IQR;
            var maxOutlier = IQR + Q3Value;
            bills = bills.Where(e => e > minOutlier && e < maxOutlier).ToList();
            var avg = (bills.Count == 0) ? 0 : bills.Sum(e=>e) / bills.Count;
            return avg;
        }
    }
}
