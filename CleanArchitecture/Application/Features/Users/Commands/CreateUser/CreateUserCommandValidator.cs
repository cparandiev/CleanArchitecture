using Application.Interfaces;
using FluentValidation;
using Application.Constants.User.Validation;
using Domain.Enums;
using Application.Helpers;

namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator(IUnitOfWork context)
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .MinimumLength(ValidationParameters.FIRST_NAME_MIN_LENGTH)
                .MaximumLength(ValidationParameters.FIRST_NAME_MAX_LENGTH);

            RuleFor(x => x.LastName)
                .NotNull()
                .MinimumLength(ValidationParameters.LAST_NAME_MIN_LENGTH)
                .MaximumLength(ValidationParameters.LAST_NAME_MAX_LENGTH);

            RuleFor(x => x.Username)
                .NotNull()
                .MinimumLength(ValidationParameters.USERNAME_MIN_LENGTH)
                .MaximumLength(ValidationParameters.USERNAME_MAX_LENGTH)
                .UniqueUsername(context);
            
            RuleFor(x => x.Password)
                .NotNull()
                .Matches(Constants.Validation.ValidationParameters.PASSWORD_REGEX)
                .WithMessage(ErrorMessages.PASSWORD_REQUIREMENTS);

            RuleFor(x => x.Email)
                .NotNull()
                .Matches(Constants.Validation.ValidationParameters.EMAIL_REGEX)
                .WithMessage(ErrorMessages.EMAIL_REQUIREMENTS);

            RuleFor(x => x.Birthdate)
                .NotNull();

            RuleFor(x => x.Blood)
                .NotNull()
                .IsValidEnum(typeof(Blood));

            RuleFor(x => x.Gender)
                .NotNull()
                .IsValidEnum(typeof(Gender));

            RuleFor(x => x.Height)
                .GreaterThanOrEqualTo(ValidationParameters.MIN_HEIGHT)
                .LessThanOrEqualTo(ValidationParameters.MAX_HEIGHT);

            RuleFor(x => x.Weight)
                .GreaterThanOrEqualTo(ValidationParameters.MIN_WEIGHT)
                .LessThanOrEqualTo(ValidationParameters.MAX_WEIGHT);
        }
    }
}
