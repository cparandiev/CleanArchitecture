using Application.Helpers;
using Application.Interfaces;
using FluentValidation;

namespace Application.Features.BodyЕxamination.Commands.AddBloodPressureExamination
{
    public class AddBloodPressureExaminationCommandValidator : AbstractValidator<AddBloodPressureExaminationCommand>
    {
        private readonly IUnitOfWork _context;

        public AddBloodPressureExaminationCommandValidator(IUnitOfWork context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            _context = context;

            RuleSet("default", () =>
            {
                RuleFor(x => x.PatientId)
                    .NotNull();

                RuleFor(x => x.ЕxaminationDate)
                    .NotNull();

                RuleFor(x => x.DiastolicBloodPressure)
                    .NotNull();

                RuleFor(x => x.SystolicBloodPressure)
                    .NotNull();
            });

            RuleSet("Authorization Phase", () =>
            {
                RuleFor(x => x.PatientId)
                    .PatientExists(context);
            });

            RuleSet("Second Phase", () =>
            {
                RuleFor(x => x.DiastolicBloodPressure)
                    .GreaterThan(0);

                RuleFor(x => x.DiastolicBloodPressure)
                    .GreaterThan(0);

                RuleFor(x => x)
                    .Must(x => x.DiastolicBloodPressure < x.SystolicBloodPressure);
            });
        }
    }
}
