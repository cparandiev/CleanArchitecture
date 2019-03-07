using Application.Features.BodyЕxamination.Models;
using Application.Interfaces;
using Application.Specifications.BodyЕxaminationResultSpecifications;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Patient.Queries.GetPatienBodyЕxaminations
{
    public class GetPatienBodyЕxaminationsQueryHandler : IRequestHandler<GetPatienBodyЕxaminationsQuery, List<BodyЕxaminationResultDto>>
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;

        public GetPatienBodyЕxaminationsQueryHandler(IUnitOfWork context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        public async Task<List<BodyЕxaminationResultDto>> Handle(GetPatienBodyЕxaminationsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _context.BodyЕxaminationResultRepository.ListAsync(new PatientBodyЕxaminationResultSpecification(request.PatientId));

            var bodyЕxaminationResultDtos = _autoMapper.Map<List<BodyЕxaminationResultDto>>(entities);

            return bodyЕxaminationResultDtos;
        }
    }
}
