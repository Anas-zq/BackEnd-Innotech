using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskProject.Entities;
using TaskProject.Models;

namespace TaskProject.Supervisors
{
    public partial class Supervisor
    {
        public async Task<List<PatientRecordModelGetAll>> GetAllPatientRecord()
        {
            var PatientRecords = await _IPatientRecordRepository.GetAllPatientRecords();
            var models = _mapper.Map<List<PatientRecordModelGetAll>>(PatientRecords);
            return models;
        }
        public async Task<PatientRecordModelGetAll> GetPatientRecordByID(int id)
        {

            var PatientRecord = await _IPatientRecordRepository.GetPatientRecordByID(id);
            return _mapper.Map<PatientRecordModelGetAll>(PatientRecord);
        }

        public async Task<PatientRecordModel> AddPatientRecord(PatientRecordModel PatientRecordModel)
        {
            var PatientRecordEntity = _mapper.Map<PatientRecord>(PatientRecordModel);
            return _mapper.Map<PatientRecordModel>(await _IPatientRecordRepository.Add(PatientRecordEntity));
        }
        public async Task<bool> UpdatePatientRecord(PatientRecordModel PatientRecordModel)
        {
            var PatientRecordEntity = _mapper.Map<PatientRecord>(PatientRecordModel);
            return await _IPatientRecordRepository.Update(PatientRecordEntity);
        }

        public async Task<bool> DeletePatientRecordById(int id)
        {
            try
            {
                await _IPatientRecordRepository.DeleteByID(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }


    }
}
