using Application.Helpers;
using Application.Interfaces;
using FluentValidation;

namespace Application.Features.Doctor.Commands.DeleteWorkingTime
{
    public class DeleteWorkingTimeCommandValidator : AbstractValidator<DeleteWorkingTimeCommand>
    {
        private readonly IUnitOfWork _context;

        public DeleteWorkingTimeCommandValidator(IUnitOfWork context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleSet("default", () => {
                RuleFor(x => x.WorkingTimeId)
                    .NotNull();
            });

            RuleSet("Authorization Phase", () => {
                RuleFor(x => x.WorkingTimeId)
                    .DoctorWorkingTimeExists(context)
                    .DependentRules(() => {
                        RuleFor(x => x)
                            .Must(VerifyDoctorIdentity);
                    });
            });

            _context = context;
        }

        private bool VerifyDoctorIdentity(DeleteWorkingTimeCommand command)
        {
            var dwt = _context.DoctorWorkingTimes.GetById(command.WorkingTimeId.Value);

            return dwt.DoctorId == command.CurrentDoctorId;
        }
    }
}
