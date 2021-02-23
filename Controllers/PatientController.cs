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

    [Route("api/Patient")]
    [ApiController]
    public class PatientController : Controller
    {
        private readonly ISupervisor _ISupervisor;
        public PatientController(ISupervisor ISupervisor)
        {
            _ISupervisor = ISupervisor;
        }

        [HttpGet("GetAllPatient")]
        [EnableCors("TheCodeBuzzPolicy")]
        public async Task<IActionResult> GetAllPatient()
        {
            var result = await _ISupervisor.GetAllPatient();
            return Ok(result);
        }
        [HttpGet("GetAllPatientWithoutRecord")]
        [EnableCors("TheCodeBuzzPolicy")]
        public async Task<IActionResult> GetAllPatientWithoutRecord()
        {
            var result = await _ISupervisor.GetAllPatientWithoutRecord();
            return Ok(result);
        }

        [HttpGet("GetAllPatientWithTimeEntry")]
        [EnableCors("TheCodeBuzzPolicy")]
        public async Task<IActionResult> GetAllPatientWithTimeEntry()
        {
            var result = await _ISupervisor.GetListPatientWithTimeEntry();
            return Ok(result);
        }
        [HttpGet("GetPatientById/{id}")]
        [EnableCors("TheCodeBuzzPolicy")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var result = await _ISupervisor.GetPatientByID(id);
            return Ok(result);
        }
        [HttpGet("GetPatientReportById/{id}")]
        [EnableCors("TheCodeBuzzPolicy")]
        public async Task<IActionResult> GetPatientReportById(int id)
        {
            var result = await _ISupervisor.GetPatientReportModelByID(id);
            return Ok(result);
        }

        [HttpPost("AddPatient")]
        [EnableCors("TheCodeBuzzPolicy")]
        public async Task<IActionResult> AddPatient([FromBody] PatientModel Patient)
        {
            try
            {
                var result = await _ISupervisor.AddPatient(Patient);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("UpdatePatient")]
        [EnableCors("TheCodeBuzzPolicy")]
        public async Task<IActionResult> UpdatePatient([FromBody] PatientModel Patient)
        {
            try
            {
                var result = await _ISupervisor.UpdatePatient(Patient);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("DeletePatientById/{id}")]
        [EnableCors("TheCodeBuzzPolicy")]
        public async Task<IActionResult> DeletePatientById(int id)
        {
            var result = await _ISupervisor.DeletePatientById(id);
            return Ok(result);
        }
    }

}
