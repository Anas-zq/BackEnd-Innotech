using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskProject.Entities;

namespace TaskProject.Repository
{
    public interface IPatientRecordRepository
    {
        Task<List<PatientRecord>> GetAllPatientRecords();
        Task<PatientRecord> GetPatientRecordByID(int id);
        Task<PatientRecord> Add(PatientRecord PatientRecord);
        Task<bool> Update(PatientRecord PatientRecord);
        Task<bool> DeleteByID(int id);
    }
}
