using Application.Helpers;
using Application.Interfaces;
using FluentValidation;

namespace Application.Features.Doctor.Commands.CreateDoctor
{
    public class CreateDoctorCommandValidator : AbstractValidator<CreateDoctorCommand>
    {
        public CreateDoctorCommandValidator(IUnitOfWork context)
        {
            RuleFor(x => x.UserId)
                .NotNull()
                .UserExists(context);

            RuleFor(x => x.Summary)
                .NotNull()
                .MinimumLength(Constants.Doctor.Validation.ValidationParameters.SUMMARY_MIN_LENGTH)
                .MaximumLength(Constants.Doctor.Validation.ValidationParameters.SUMMARY_MAX_LENGTH);

            RuleFor(x => x.ClinicId)
                .NotNull()
                .ClinicExists(context);
        }
    }
}
