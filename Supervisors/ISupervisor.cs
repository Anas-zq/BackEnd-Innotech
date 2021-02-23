using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskProject.Models;

namespace TaskProject.Supervisors
{
   public interface ISupervisor
    {
        #region Patient
        Task<List<PatientModel>> GetAllPatient();
        Task<List<PatientModelWithoutRecord>> GetAllPatientWithoutRecord();
        Task<List<PatientListModel>> GetListPatientWithTimeEntry();

        Task<PatientModel> GetPatientByID(int id);

        Task<PatientModel> AddPatient(PatientModel PatientModel);

        Task<bool> UpdatePatient(PatientModel PatientModel);

        Task<bool> DeletePatientById(int id);
        #endregion

        #region PatientRecord
        Task<List<PatientRecordModelGetAll>> GetAllPatientRecord();

        Task<PatientRecordModelGetAll> GetPatientRecordByID(int id);
        Task<PatientReportModel> GetPatientReportModelByID(int id);

        Task<PatientRecordModel> AddPatientRecord(PatientRecordModel PatientRecordModel);

        Task<bool> UpdatePatientRecord(PatientRecordModel PatientRecordModel);

        Task<bool> DeletePatientRecordById(int id);
        #endregion
    }
}
