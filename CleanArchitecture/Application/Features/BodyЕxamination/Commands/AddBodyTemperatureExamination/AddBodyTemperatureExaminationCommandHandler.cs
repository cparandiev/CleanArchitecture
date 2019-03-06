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

namespace Application.Features.BodyЕxamination.Commands.AddBodyTemperatureExamination
{
    public class AddBodyTemperatureExaminationCommandHandler : IRequestHandler<AddBodyTemperatureExaminationCommand, Unit>
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;

        public AddBodyTemperatureExaminationCommandHandler(IUnitOfWork context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        public async Task<Unit> Handle(AddBodyTemperatureExaminationCommand request, CancellationToken cancellationToken)
        {
            var entity = _autoMapper.Map<BodyЕxaminationResult>(request);

            var bodyTemperatureType = _context.BodyЕxaminationTypeRepository.GetSingleBySpec(new BodyЕxaminationTypeByValueSpecification(BodyExaminationType.BodyTemperature));

            entity.BodyЕxaminationResultTypes.Add(new BodyЕxaminationResultType { Result = entity, Type = bodyTemperatureType });

            await _context.BodyЕxaminationResultRepository.AddAsync(entity);

            await _context.CompleteAsync();

            return Unit.Value;
        }
    }
}
