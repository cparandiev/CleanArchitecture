using System.Threading;
using System.Threading.Tasks;
using Application.Features.Patient.Models;
using Application.Interfaces;
using Application.Specifications.PatientSpecifications;
using AutoMapper;
using MediatR;

namespace Application.Features.Patient.Commands.LoginPatient
{
    public class LoginPatientCommandHandler : IRequestHandler<LoginPatientCommand, PatientDto>
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;

        public LoginPatientCommandHandler(IUnitOfWork context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        public Task<PatientDto> Handle(LoginPatientCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.Patients.GetSingleBySpec(new PatientWithUserPropsSpecifications(request.Username));

            var patientDto = _autoMapper.Map<PatientDto>(entity);

            return Task.FromResult(patientDto);
        }
    }
}
