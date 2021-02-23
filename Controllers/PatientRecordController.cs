using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskProject.Models;
using TaskProject.Supervisors;

namespace TaskProject.Controllers
{
    [Route("api/PatientRecord")]
    [ApiController]
    public class PatientRecordController : Controller
    {
        private readonly ISupervisor _ISupervisor;
        public PatientRecordController(ISupervisor ISupervisor)
        {
            _ISupervisor = ISupervisor;
        }

        [HttpGet("GetAllPatientRecord")]
        [EnableCors("TheCodeBuzzPolicy")]
        public async Task<IActionResult> GetAllPatientRecord()
        {
            var result = await _ISupervisor.GetAllPatientRecord();
            return Ok(result);
        }

        [HttpGet("GetPatientRecordById/{id}")]
        [EnableCors("TheCodeBuzzPolicy")]
        public async Task<IActionResult> GetPatientRecordById(int id)
        {
            var result = await _ISupervisor.GetPatientRecordByID(id);
            return Ok(result);
        }

        [HttpPost("AddPatientRecord")]
        [EnableCors("TheCodeBuzzPolicy")]
        public async Task<IActionResult> AddPatientRecord([FromBody] PatientRecordModel PatientRecord)
        {
            try
            {
                var result = await _ISupervisor.AddPatientRecord(PatientRecord);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("UpdatePatientRecord")]
        [EnableCors("TheCodeBuzzPolicy")]
        public async Task<IActionResult> UpdatePatientRecord([FromBody] PatientRecordModel PatientRecord)
        {
            try
            {
                var result = await _ISupervisor.UpdatePatientRecord(PatientRecord);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("DeletePatientRecordById/{id}")]
        [EnableCors("TheCodeBuzzPolicy")]
        public async Task<IActionResult> DeletePatientRecordById(int id)
        {
            var result = await _ISupervisor.DeletePatientRecordById(id);
            return Ok(result);
        }
    }
}
