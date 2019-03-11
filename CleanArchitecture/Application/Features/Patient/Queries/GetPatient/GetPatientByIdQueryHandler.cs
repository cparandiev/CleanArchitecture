using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Patient.Models;
using Application.Interfaces;
using Application.Specifications.PatientSpecifications;
using AutoMapper;
using MediatR;

namespace Application.Features.Patient.Queries.GetPatient
{
    public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, PatientDto>
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;

        public GetPatientByIdQueryHandler(IUnitOfWork context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        public Task<PatientDto> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = _context.Patients.GetSingleBySpec(new PatientWithUserPropsSpecifications(request.PatientId.Value));
            
            var patientDto = _autoMapper.Map<PatientDto>(entity);
            
            return Task.FromResult(patientDto);
        }
    }
}
