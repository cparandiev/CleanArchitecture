using Application.Helpers;
using Application.Interfaces;
using FluentValidation;

namespace Application.Features.BodyExamination.Commands.AddBodyTemperatureExamination
{
    public class AddBodyTemperatureExaminationCommandValidator : AbstractValidator<AddBodyTemperatureExaminationCommand>
    {
        private readonly IUnitOfWork _context;

        public AddBodyTemperatureExaminationCommandValidator(IUnitOfWork context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            _context = context;

            RuleSet("default", () =>
            {
                RuleFor(x => x.PatientId)
                    .NotNull();

                RuleFor(x => x.ExaminationDate)
                    .NotNull();

                RuleFor(x => x.Temperature)
                    .NotNull();
            });

            RuleSet("Authorization Phase", () =>
            {
                RuleFor(x => x.PatientId)
                    .PatientExists(context);
            });

            RuleSet("Second Phase", () =>
            {
                RuleFor(x => x.Temperature)
                    .GreaterThan(0)
                    .LessThan(50);
            });
        }
    }
}
