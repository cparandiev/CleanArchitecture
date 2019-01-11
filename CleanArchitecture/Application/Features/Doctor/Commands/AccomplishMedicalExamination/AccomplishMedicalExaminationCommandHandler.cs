using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.MedicalExaminationResultAggregate;
using MediatR;

namespace Application.Features.Doctor.Commands.AccomplishMedicalExamination
{
    public class AccomplishMedicalExaminationCommandHandler : IRequestHandler<AccomplishMedicalExaminationCommand, Unit>
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;

        public AccomplishMedicalExaminationCommandHandler(IUnitOfWork context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        public async Task<Unit> Handle(AccomplishMedicalExaminationCommand request, CancellationToken cancellationToken)
        {
            var mdr = _context.MedicalExaminationRequests.GetById(request.RequestId.Value);

            mdr.IsAccomplished = true;
            mdr.Result = _autoMapper.Map<MedicalExaminationResult>(request);

            await _context.CompleteAsync();

            return Unit.Value;
        }
    }
}
