using Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Doctor.Commands.DeleteWorkingTime
{
    public class DeleteWorkingTimeCommandHandler : IRequestHandler<DeleteWorkingTimeCommand, Unit>
    {
        private readonly IUnitOfWork _context;

        public DeleteWorkingTimeCommandHandler(IUnitOfWork context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteWorkingTimeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.DoctorWorkingTimes.GetByIdAsync(request.WorkingTimeId.Value);

            await _context.DoctorWorkingTimes.DeleteAsync(entity);

            await _context.CompleteAsync(); // todo

            return Unit.Value;
        }
    }
}