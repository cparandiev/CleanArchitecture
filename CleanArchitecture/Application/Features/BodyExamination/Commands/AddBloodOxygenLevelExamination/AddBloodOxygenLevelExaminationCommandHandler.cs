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

namespace Application.Features.BodyExamination.Commands.AddBloodOxygenLevelExamination
{
    public class AddBloodOxygenLevelExaminationCommandHandler : IRequestHandler<AddBloodOxygenLevelExaminationCommand, Unit>
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;

        public AddBloodOxygenLevelExaminationCommandHandler(IUnitOfWork context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        public async Task<Unit> Handle(AddBloodOxygenLevelExaminationCommand request, CancellationToken cancellationToken)
        {
            var entity = _autoMapper.Map<BodyExaminationResult>(request);

            var bloodOxygenType = _context.BodyExaminationTypeRepository.GetSingleBySpec(new BodyExaminationTypeByValueSpecification(Domain.Enums.BodyExaminationType.BloodOxygenLevel));

            entity.BodyExaminationResultTypes.Add(new BodyExaminationResultType { Result = entity, Type = bloodOxygenType });

            await _context.BodyExaminationResultRepository.AddAsync(entity);

            await _context.CompleteAsync();

            return Unit.Value;
        }
    }
}
