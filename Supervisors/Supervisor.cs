using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TaskProject.Repository;

namespace TaskProject.Supervisors
{
    public partial class Supervisor : ISupervisor
    {
        private IPatientRepository _IPatientRepository;
        private IPatientRecordRepository _IPatientRecordRepository;
        private readonly IMapper _mapper;

        public Supervisor(IPatientRepository IPatientRepository, IPatientRecordRepository IPatientRecordRepository, IMapper mapper)
        {
            _IPatientRepository = IPatientRepository;
            _IPatientRecordRepository = IPatientRecordRepository;
            _mapper = mapper;
        }
    }
}
