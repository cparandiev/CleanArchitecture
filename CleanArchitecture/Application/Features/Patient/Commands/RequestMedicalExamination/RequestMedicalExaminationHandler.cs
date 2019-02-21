using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.MedicalExaminationRequestAggregate;
using MediatR;

namespace Application.Features.Patient.Commands.RequestMedicalExamination
{
    public class RequestMedicalExaminationHandler : IRequestHandler<RequestMedicalExaminationCommand>
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;

        public RequestMedicalExaminationHandler(IUnitOfWork context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        public async Task<Unit> Handle(RequestMedicalExaminationCommand request, CancellationToken cancellationToken)
        {
            var medicalExaminationRequestEntity = _autoMapper.Map<Domain.Entities.MedicalExaminationRequestAggregate.MedicalExaminationRequest>(request);

            await _context.MedicalExaminationRequests.AddAsync(medicalExaminationRequestEntity);

            await _context.CompleteAsync();

            return Unit.Value;
        }
    }
}
