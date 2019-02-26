using Application.Features.MedicalExaminationRequest.Models;
using Application.Interfaces;
using Application.Specifications.MedicalExaminationSpecifications;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Doctor.Queries.GetDoctorMedicalExaminations
{
    public class GetDoctorMedicalExaminationsQueryHandler : IRequestHandler<GetDoctorMedicalExaminationsQuery, List<MedicalExaminationRequestDto>>
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;

        public GetDoctorMedicalExaminationsQueryHandler(IUnitOfWork context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        public async Task<List<MedicalExaminationRequestDto>> Handle(GetDoctorMedicalExaminationsQuery query, CancellationToken cancellationToken)
        {
            var entities = await _context.MedicalExaminationRequests.ListAsync(new MedicalExaminationWithResultsSpecifications(query.DoctorId.Value));

            var medicalExaminationRequests = _autoMapper.Map<List<MedicalExaminationRequestDto>>(entities);

            return medicalExaminationRequests;
        }
    }
}
