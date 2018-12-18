using Application.Interfaces;
using Application.Specifications.UserSpecifications;
using FluentValidation;
using Application.Constants.User.Validation;

namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IUnitOfWork _context;

        public CreateUserCommandValidator(IUnitOfWork context)
        {
            _context = context;

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
                .MaximumLength(ValidationParameters.USERNAME_MAX_LENGTH);

            RuleFor(x => x.Username)
                .Must(UniqueName)
                .WithMessage(ErrorMessages.UNIQUE_USERNAME);

            RuleFor(x => x.Password)
                .NotNull()
                .Matches(Constants.Validation.ValidationParameters.PASSWORD_REGEX)
                .WithMessage(ErrorMessages.PASSWORD_REQUIREMENTS);

            RuleFor(x => x.Email)
                .NotNull()
                .Matches(Constants.Validation.ValidationParameters.EMAIL_REGEX)
                .WithMessage(ErrorMessages.EMAIL_REQUIREMENTS);

            RuleFor(x => x.Height)
                .GreaterThanOrEqualTo(ValidationParameters.MIN_HEIGHT)
                .LessThanOrEqualTo(ValidationParameters.MAX_HEIGHT);

            RuleFor(x => x.Weight)
                .GreaterThanOrEqualTo(ValidationParameters.MIN_WEIGHT)
                .LessThanOrEqualTo(ValidationParameters.MAX_WEIGHT);
        }

        private bool UniqueName(string name)
        {
            return _context.Users.Count(new UserWithRolesSpecification(name)) == 0;
        }
    }
}
