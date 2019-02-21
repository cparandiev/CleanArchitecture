using System.Threading.Tasks;
using Application.Features.Patient.Commands.CreatePatient;
using Application.Features.Patient.Services.Interfaces;
using Application.Interfaces;
using Application.Specifications.RoleSpecifications;
using AutoMapper;
using Domain.Entities.UserAggregate;

namespace Application.Features.Patient.Services
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;

        public PatientService(IUnitOfWork context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        public async Task<Domain.Entities.PatientAggregate.Patient> CreatePatient(User user, CreatePatientCommand createPatientCommand)
        {
            var patientRole = _context.Roles.GetSingleBySpec(new RoleByValueSpecifications(Domain.Enums.Role.Patient));

            user.UserRoles.Add(new UserRole { Role = patientRole });

            var patient = _autoMapper.Map<Domain.Entities.PatientAggregate.Patient>(createPatientCommand);
            patient.User = user;

            await _context.Patients.AddAsync(patient);

            return patient;
        }
    }
}
