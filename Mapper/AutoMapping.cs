using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TaskProject.Entities;
using TaskProject.Models;

namespace TaskProject.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Patient, PatientModel>().ReverseMap();
            CreateMap<PatientRecord, PatientRecordModel>().ReverseMap(); 
            CreateMap<PatientReport, PatientReportModel>().ReverseMap();
            CreateMap<Patient, PatientModelWithoutRecord>().ReverseMap();
            CreateMap<PatientRecord, PatientRecordModelGetAll>().ReverseMap();

        }
    }
  
}
