using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskProject.Entities;

namespace TaskProject.Repository
{
    public class PatientRecordRepository : IPatientRecordRepository
    {
        private readonly PatientContext _context;

        public PatientRecordRepository(PatientContext context)
        {
            _context = context;
        }
        public async Task<List<PatientRecord>> GetAllPatientRecords()
        {
            var PatientRecords = await _context.PatientRecords.Include(e=>e.Patient).ToListAsync();
            return PatientRecords;
        }

        public async Task<PatientRecord> GetPatientRecordByID(int id)
        {
            var PatientRecord = await _context.PatientRecords.Where(e => e.ID == id).Include(e=>e.Patient)
                                            .FirstOrDefaultAsync();
            return PatientRecord;

        }

        public async Task<PatientRecord> Add(PatientRecord PatientRecord)
        {
            _context.Add(PatientRecord);
            await _context.SaveChangesAsync();
            return PatientRecord;
        }

        public async Task<bool> Update(PatientRecord PatientRecord)
        {
            _context.Update(PatientRecord);
            var success = await _context.SaveChangesAsync();
            if (success == 0)
                return false;
            return true;
        }
        public async Task<bool> DeleteByID(int id)
        {
            var PatientRecord = await GetPatientRecordByID(id);
            _context.Remove(PatientRecord);
            var success = await _context.SaveChangesAsync();
            if (success == 0)
                return false;
            return true;
        }
    }
}
