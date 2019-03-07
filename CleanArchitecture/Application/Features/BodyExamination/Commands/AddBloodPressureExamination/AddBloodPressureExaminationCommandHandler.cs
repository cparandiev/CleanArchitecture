using Application.Interfaces;
using Application.Specifications.BodyExaminationTypeSpecifications;
using AutoMapper;
using Domain.Entities.BodyExaminationResultAggregate;
using Domain.Enums;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.BodyExamination.Commands.AddBloodPressureExamination
{
    public class AddBloodPressureExaminationCommandHandler : IRequestHandler<AddBloodPressureExaminationCommand, Unit>
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;

        public AddBloodPressureExaminationCommandHandler(IUnitOfWork context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        public async Task<Unit> Handle(AddBloodPressureExaminationCommand request, CancellationToken cancellationToken)
        {
            var entity = _autoMapper.Map<BodyExaminationResult>(request);

            var bloodPressureType = _context.BodyExaminationTypeRepository.GetSingleBySpec(new BodyExaminationTypeByValueSpecification(Domain.Enums.BodyExaminationType.BloodPressure));

            entity.BodyExaminationResultTypes.Add(new BodyExaminationResultType { Result = entity, Type = bloodPressureType });

            await _context.BodyExaminationResultRepository.AddAsync(entity);

            await _context.CompleteAsync();

            return Unit.Value;
        }
    }
}
