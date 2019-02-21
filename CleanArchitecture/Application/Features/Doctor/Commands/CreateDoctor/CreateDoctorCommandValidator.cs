using Application.Features.Patient.Commands.CreatePatient;
using Application.Helpers;
using Application.Interfaces;
using FluentValidation;

namespace Application.Features.Doctor.Commands.CreateDoctor
{
    public class CreateDoctorCommandValidator : AbstractValidator<CreateDoctorCommand>
    {
        public CreateDoctorCommandValidator(IUnitOfWork context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Username)
                .NotNull();

            RuleFor(x => x.Summary)
                .NotNull()
                .MinimumLength(Constants.Doctor.Validation.ValidationParameters.SUMMARY_MIN_LENGTH)
                .MaximumLength(Constants.Doctor.Validation.ValidationParameters.SUMMARY_MAX_LENGTH);

            RuleFor(x => x.ClinicId)
                .NotNull()
                .GreaterThan(0)
                .ClinicExists(context);

            RuleFor(x => x.CreatePatientCommand)
                .SetValidator(new CreatePatientCommandValidator(context));
        }
    }
}
