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
        public async Task<List<PatientModel>> GetAllPatient()
        {
            var Patients = await _IPatientRepository.GetAllPatients();
            return _mapper.Map<List<PatientModel>>(Patients);
        }
        
       public async Task<List<PatientModelWithoutRecord>> GetAllPatientWithoutRecord()
        {
            var Patients = await _IPatientRepository.GetAllPatients();
            return _mapper.Map<List<PatientModelWithoutRecord>>(Patients);
        }
        public async Task<List<PatientListModel>> GetListPatientWithTimeEntry()
        {
            return await _IPatientRepository.GetAllPatientsWithTimeEntry();

        }
        public async Task<PatientModel> GetPatientByID(int id)
        {

            var Patient = await _IPatientRepository.GetPatientByID(id);
            var model = _mapper.Map<PatientModel>(Patient);
            model.DateOfBirthAsString = model.DateOfBirth.ToString("yyyy/MM/dd");
            return model;
        }
        public async Task<PatientReportModel> GetPatientReportModelByID(int id)
        {

            var patient = await _IPatientRepository.GetReportForPatientByID(id);
            var patientReportModel = _mapper.Map<PatientReportModel>(patient);
            foreach (var patientx in patientReportModel.ListOfPatientWithSameTwoDisease)
            {
                patientx.DateOfBirthAsString = patientx.DateOfBirth.ToString("yyyy/MM/dd");
            }
            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
            patientReportModel.MonthHighVisit = (patient.MonthHighVisit != 0) ? mfi.GetMonthName(patient.MonthHighVisit).ToString() : "none";
            patientReportModel.FifthRecordExist = (patientReportModel.FifthPatientRecord == null) ? false : true;
            patientReportModel.ShowArray = (patientReportModel.ListOfPatientWithSameTwoDisease.Count == 0) ? false : true;
            patientReportModel.Columns = setColumns();
            return patientReportModel;
        }

        public async Task<PatientModel> AddPatient(PatientModel PatientModel)
        {
            var PatientEntity = _mapper.Map<Patient>(PatientModel);
            return _mapper.Map<PatientModel>(await _IPatientRepository.Add(PatientEntity));
        }
        public async Task<bool> UpdatePatient(PatientModel PatientModel)
        {
            var PatientEntity = await _IPatientRepository.GetPatientByID(PatientModel.ID);
            PatientEntity.Name = PatientModel.Name;
            PatientEntity.Email = PatientModel.Email;
            PatientEntity.DateOfBirth = PatientModel.DateOfBirth;
            return await _IPatientRepository.Update(PatientEntity);
        }

        public async Task<bool> DeletePatientById(int id)
        {
            try
            {
                await _IPatientRepository.DeleteByID(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }
        private List<Columns> setColumns()
        {
            List<Columns> columns = new List<Columns>();
            columns.Add(new Columns() { DataField = "id", Text = "#" });
            columns.Add(new Columns() { DataField = "name", Text = "Name" });
            columns.Add(new Columns() { DataField = "email", Text = "Email" });
            columns.Add(new Columns() { DataField = "dateOfBirthAsString", Text = "Date Of Birth" });
            return columns;
        }

    }

}
