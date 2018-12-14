using System.Threading;
using System.Threading.Tasks;
using Application.Features.Patient.Models;
using Application.Interfaces;
using Application.Specifications.PatientSpecifications;
using AutoMapper;
using MediatR;

namespace Application.Features.Patient.Queries.GetPatient
{
    public class GetPatientQueryHandler : IRequestHandler<GetPatientQuery, PatientDto>
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;

        public GetPatientQueryHandler(IUnitOfWork context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        public Task<PatientDto> Handle(GetPatientQuery request, CancellationToken cancellationToken)
        {
            var entity = _context.Patients.GetSingleBySpec(new PatientWithUserPropsSpecifications(request.UserId));

            return Task.FromResult(_autoMapper.Map<PatientDto>(entity));
        }
    }
}
