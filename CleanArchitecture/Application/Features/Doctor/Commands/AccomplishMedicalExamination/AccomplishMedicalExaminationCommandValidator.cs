using System;
using Application.Constants.Validation;
using Application.Helpers;
using Application.Interfaces;
using FluentValidation;

namespace Application.Features.Doctor.Commands.AccomplishMedicalExamination
{
    public class AccomplishMedicalExaminationCommandValidator : AbstractValidator<AccomplishMedicalExaminationCommand>
    {
        private readonly IUnitOfWork _context;

        public AccomplishMedicalExaminationCommandValidator(IUnitOfWork context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            _context = context;

            RuleSet("default", () =>{
                RuleFor(x => x.RequestId)
                    .NotNull();

                RuleFor(x => x.Notes)
                    .NotNull()
                    .MinimumLength(ValidationParameters.NOTES_MIN_LENGTH)
                    .MaximumLength(ValidationParameters.NOTES_MAX_LENGTH);
            });

            RuleSet("Authorization Phase", () => {
                RuleFor(x => x.RequestId)
                    .MedicalExaminationRequestExists(context)
                    .DependentRules(() => {
                        RuleFor(x => x)
                            .Must(VerifyDoctorIdentity);
                    });
            });

            RuleSet("Second Phase", () => {
                RuleFor(x => x.RequestId)
                  .Must(VerifyRequestApproval)
                  .WithMessage(ErrorMessages.REJECTED_REQUEST);

                RuleFor(x => x.RequestId)
                    .None(context.MedicalExaminationRequests,
                        prop => entity => entity.Id == prop && (entity.IsAccomplished.HasValue && entity.IsAccomplished.Value),
                        ErrorMessages.ALREADY_ACCOMPLISHED_REQUEST);
            });
        }

        private bool VerifyRequestApproval(int? requestId)
        {
            var mdr = _context.MedicalExaminationRequests.GetById(requestId.Value);

            return mdr.IsApproved.HasValue && mdr.IsApproved.Value;
        }

        private bool VerifyDoctorIdentity(AccomplishMedicalExaminationCommand command)
        {
            var mdr = _context.MedicalExaminationRequests.GetById(command.RequestId.Value);

            return mdr.DoctorId == command.CurrentDoctorId;
        }
    }
}
