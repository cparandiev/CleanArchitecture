using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.Doctor.Commands.ReviewMedicalExamination
{
    public class ReviewMedicalExaminationCommandHandler : IRequestHandler<ReviewMedicalExaminationCommand>
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;

        public ReviewMedicalExaminationCommandHandler(IUnitOfWork context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        public async Task<Unit> Handle(ReviewMedicalExaminationCommand request, CancellationToken cancellationToken)
        {
            var mdr = _context.MedicalExaminationRequests.GetById(request.RequestId.Value);

            mdr.IsApproved = request.IsApproved;

            await _context.CompleteAsync();

            return Unit.Value;
        }
    }
}
