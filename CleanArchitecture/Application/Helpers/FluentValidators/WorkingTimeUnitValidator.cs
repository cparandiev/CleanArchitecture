using Application.Constants.Validation;
using Application.Features.Doctor.Models;
using FluentValidation;

namespace Application.Helpers.FluentValidators
{
    public class WorkingTimeUnitValidator: AbstractValidator<WorkingTimeUnit>
    {

        public WorkingTimeUnitValidator()
        {
            RuleFor(x => x.Open)
                .NotNull();

            RuleFor(x => x.Close)
                .NotNull();

            RuleFor(x => x)
                .Must(x => x.Open.Value < x.Close.Value)
                .WithMessage(ErrorMessages.INVALID_WORKING_TIME_UNIT)
                .OverridePropertyName(ErrorNames.ModelCompossibleErrorName);
        }
    }
}
