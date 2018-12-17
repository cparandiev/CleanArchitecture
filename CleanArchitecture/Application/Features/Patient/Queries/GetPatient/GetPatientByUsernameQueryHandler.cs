using Application.Features.Patient.Models;
using Application.Interfaces;
using Application.Specifications.PatientSpecifications;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Patient.Queries.GetPatient
{
    public class GetPatientByUsernameQueryHandler : IRequestHandler<GetPatientByUsernameQuery, PatientDto>
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;

        public GetPatientByUsernameQueryHandler(IUnitOfWork context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        public Task<PatientDto> Handle(GetPatientByUsernameQuery request, CancellationToken cancellationToken)
        {
            var entity = _context.Patients.GetSingleBySpec(new PatientWithUserPropsSpecifications(request.Username));

            var patientDto = _autoMapper.Map<PatientDto>(entity);

            return Task.FromResult(patientDto);
        }
    }
}
