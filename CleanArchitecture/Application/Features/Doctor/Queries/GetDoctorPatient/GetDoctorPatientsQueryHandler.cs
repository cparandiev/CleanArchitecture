using Application.Features.Patient.Models;
using Application.Interfaces;
using Application.Specifications.PatientSpecifications;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Doctor.Queries.GetDoctorPatient
{
    public class GetDoctorPatientsQueryHandler : IRequestHandler<GetDoctorPatientsQuery, List<PatientDto>>
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;

        public GetDoctorPatientsQueryHandler(IUnitOfWork context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        public async Task<List<PatientDto>> Handle(GetDoctorPatientsQuery request, CancellationToken cancellationToken)
        {
            var patients = await _context.Patients.ListAsync(new DoctorPatientsSpecification(request.DoctorId.Value));

            var patientsDtos = _autoMapper.Map<List<PatientDto>>(patients);

            return patientsDtos;
        }
    }
}
