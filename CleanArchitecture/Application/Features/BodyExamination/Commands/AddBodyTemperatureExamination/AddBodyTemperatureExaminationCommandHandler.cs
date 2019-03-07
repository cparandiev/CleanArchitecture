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

namespace Application.Features.BodyExamination.Commands.AddBodyTemperatureExamination
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
            var entity = _autoMapper.Map<BodyExaminationResult>(request);

            var bodyTemperatureType = _context.BodyExaminationTypeRepository.GetSingleBySpec(new BodyExaminationTypeByValueSpecification(Domain.Enums.BodyExaminationType.BodyTemperature));

            entity.BodyExaminationResultTypes.Add(new BodyExaminationResultType { Result = entity, Type = bodyTemperatureType });

            await _context.BodyExaminationResultRepository.AddAsync(entity);

            await _context.CompleteAsync();

            return Unit.Value;
        }
    }
}
