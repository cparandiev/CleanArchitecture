using Application.Features.MedicalExaminationRequest.Models;
using Application.Interfaces;
using Application.Specifications.MedicalExaminationSpecifications;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Patient.Queries.GetPatientMedicalExaminations
{
    public class GetPatientMedicalExaminationsQueryHandler : IRequestHandler<GetPatientMedicalExaminationsQuery, List<MedicalExaminationRequestDto>>
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;

        public GetPatientMedicalExaminationsQueryHandler(IUnitOfWork context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        public Task<List<MedicalExaminationRequestDto>> Handle(GetPatientMedicalExaminationsQuery request, CancellationToken cancellationToken)
        {
            var entities = _context.MedicalExaminationRequests.List(new MedicalExaminationWithResultsSpecifications(request.PatientId));

            var medicalExaminationRequestDtos = _autoMapper.Map<List<MedicalExaminationRequestDto>>(entities);

            return Task.FromResult(medicalExaminationRequestDtos);
        }
    }
}
