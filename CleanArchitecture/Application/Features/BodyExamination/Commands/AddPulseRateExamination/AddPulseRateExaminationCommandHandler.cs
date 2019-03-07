using Application.Interfaces;
using Application.Specifications.BodyExaminationTypeSpecifications;
using AutoMapper;
using Domain.Entities.BodyExaminationResultAggregate;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.BodyExamination.Commands.AddPulseRateExamination
{
    public class AddPulseRateExaminationCommandHandler : IRequestHandler<AddPulseRateExaminationCommand, Unit>
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;

        public AddPulseRateExaminationCommandHandler(IUnitOfWork context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        public async Task<Unit> Handle(AddPulseRateExaminationCommand request, CancellationToken cancellationToken)
        {
            var entity = _autoMapper.Map<BodyExaminationResult>(request);

            var pulseRateType = _context.BodyExaminationTypeRepository.GetSingleBySpec(new BodyExaminationTypeByValueSpecification(Domain.Enums.BodyExaminationType.PulseRate));

            entity.BodyExaminationResultTypes.Add(new BodyExaminationResultType { Result = entity, Type = pulseRateType });

            await _context.BodyExaminationResultRepository.AddAsync(entity);

            await _context.CompleteAsync();

            return Unit.Value;
        }
    }
}
