using Application.Interfaces;
using Application.Specifications.BodyЕxaminationTypeSpecifications;
using AutoMapper;
using Domain.Entities.BodyЕxaminationResultAggregate;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.BodyЕxamination.Commands.AddPulseRateExamination
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
            var entity = _autoMapper.Map<BodyЕxaminationResult>(request);

            var pulseRateType = _context.BodyЕxaminationTypeRepository.GetSingleBySpec(new BodyЕxaminationTypeByValueSpecification(BodyExaminationType.PulseRate));

            entity.BodyЕxaminationResultTypes.Add(new BodyЕxaminationResultType { Result = entity, Type = pulseRateType });

            await _context.BodyЕxaminationResultRepository.AddAsync(entity);

            await _context.CompleteAsync();

            return Unit.Value;
        }
    }
}
