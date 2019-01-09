using Application.Constants.Validation;
using Application.Features.Doctor.Models;
using FluentValidation;

namespace Application.Helpers.FluentValidators
{
    public class WorkingTimeUnitValidator: AbstractValidator<WorkingTimeUnit>
    {

        public WorkingTimeUnitValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Open)
                .NotNull();

            RuleFor(x => x.Close)
                .NotNull()
                .GreaterThan(m => m.Open.Value)
                .When(m => m.Open.HasValue);
        }
    }
}
