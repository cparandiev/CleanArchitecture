using Application.Helpers;
using Application.Interfaces;
using FluentValidation;

namespace Application.Features.Doctor.Commands.ReviewMedicalExamination
{
    public class ReviewMedicalExaminationCommandValidator : AbstractValidator<ReviewMedicalExaminationCommand>
    {
        private readonly IUnitOfWork _context;

        public ReviewMedicalExaminationCommandValidator(IUnitOfWork context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            _context = context;

            RuleSet("default", () => {
                RuleFor(x => x.RequestId)
                    .NotNull()
                    .GreaterThan(0);

                RuleFor(x => x.IsApproved)
                    .NotNull();
            });

            RuleSet("Authorization Phase", () => {
                RuleFor(x => x.RequestId)
                    .MedicalExaminationRequestExists(context)
                    .DependentRules(() => {
                        RuleFor(x => x)
                            .Must(VerifyDoctorIdentity);
                    });
            });
        }

        private bool VerifyDoctorIdentity(ReviewMedicalExaminationCommand command)
        {
            var mdr = _context.MedicalExaminationRequests.GetById(command.RequestId.Value);

            return mdr.DoctorId == command.CurrentDoctorId;
        }
    }
}
