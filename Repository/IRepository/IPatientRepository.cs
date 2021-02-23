using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskProject.Entities;
using TaskProject.Models;

namespace TaskProject.Repository
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAllPatients();
        Task<List<PatientListModel>> GetAllPatientsWithTimeEntry();
        Task<Patient> GetPatientByID(int id);
        Task<PatientReport> GetReportForPatientByID(int id);
        Task<Patient> Add(Patient Patient);
        Task<bool> Update(Patient Patient);
        Task<bool> DeleteByID(int id);
    }
}
