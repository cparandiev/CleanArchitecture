using Application.Interfaces;
using Application.Specifications.BodyЕxaminationTypeSpecifications;
using AutoMapper;
using Domain.Entities.BodyЕxaminationResultAggregate;
using Domain.Enums;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.BodyЕxamination.Commands.AddBloodPressureExamination
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
            var entity = _autoMapper.Map<BodyЕxaminationResult>(request);

            var bloodPressureType = _context.BodyЕxaminationTypeRepository.GetSingleBySpec(new BodyЕxaminationTypeByValueSpecification(BodyExaminationType.BloodPressure));

            entity.BodyЕxaminationResultTypes.Add(new BodyЕxaminationResultType { Result = entity, Type = bloodPressureType });

            await _context.BodyЕxaminationResultRepository.AddAsync(entity);

            await _context.CompleteAsync();

            return Unit.Value;
        }
    }
}
