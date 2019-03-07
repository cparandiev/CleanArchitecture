using Application.Features.BodyExamination.Models;
using Application.Interfaces;
using Application.Specifications.BodyExaminationResultSpecifications;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Patient.Queries.GetPatienBodyExaminations
{
    public class GetPatienBodyExaminationsQueryHandler : IRequestHandler<GetPatienBodyExaminationsQuery, List<BodyExaminationResultDto>>
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;

        public GetPatienBodyExaminationsQueryHandler(IUnitOfWork context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        public async Task<List<BodyExaminationResultDto>> Handle(GetPatienBodyExaminationsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _context.BodyExaminationResultRepository.ListAsync(new PatientBodyExaminationResultSpecification(request.PatientId));

            var bodyExaminationResultDtos = _autoMapper.Map<List<BodyExaminationResultDto>>(entities);

            return bodyExaminationResultDtos;
        }
    }
}
