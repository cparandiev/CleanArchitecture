using Application.Helpers;
using Application.Interfaces;
using FluentValidation;

namespace Application.Features.BodyExamination.Commands.AddBloodOxygenLevelExamination
{
    public class AddBloodOxygenLevelExaminationCommandValidator : AbstractValidator<AddBloodOxygenLevelExaminationCommand>
    {
        private readonly IUnitOfWork _context;
        
        public AddBloodOxygenLevelExaminationCommandValidator(IUnitOfWork context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            _context = context;

            RuleSet("default", () => {
                RuleFor(x => x.PatientId)
                    .NotNull();

                RuleFor(x => x.ExaminationDate)
                    .NotNull();

                RuleFor(x => x.OxygenLevel)
                    .NotNull();
            });

            RuleSet("Authorization Phase", () => {
                RuleFor(x => x.PatientId)
                    .PatientExists(context);
            });

            RuleSet("Second Phase", () => {
                RuleFor(x => x.OxygenLevel)
                    .GreaterThan(0)
                    .LessThan(100);
            });
        }
    }
}
