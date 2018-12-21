using Application.Constants.User.Validation;
using Application.Interfaces;
using Application.Specifications.DoctorSpecifications;
using FluentValidation;

namespace Application.Features.Doctor.Commands.LoginDoctor
{
    public class LoginDoctorCommandValidator : AbstractValidator<LoginDoctorCommand>
    {
        private readonly IUnitOfWork _context;
        private readonly ISecurePasswordHasher _securePasswordHasher;

        public LoginDoctorCommandValidator(IUnitOfWork context, ISecurePasswordHasher securePasswordHasher)
        {
            _context = context;
            _securePasswordHasher = securePasswordHasher;

            RuleFor(x => x.Username)
                .NotNull()
                .MinimumLength(ValidationParameters.USERNAME_MIN_LENGTH)
                .MaximumLength(ValidationParameters.USERNAME_MAX_LENGTH);

            RuleFor(x => x.Password)
                .NotNull()
                .Matches(Constants.Validation.ValidationParameters.PASSWORD_REGEX)
                .WithMessage(ErrorMessages.PASSWORD_REQUIREMENTS);

            RuleFor(x => x)
                .Must(VerifyCredentials)
                .When(x => x.Password != null && x.Username != null)
                .WithMessage(ErrorMessages.INVALID_CREDENTIALS)
                .OverridePropertyName(Constants.Validation.ErrorNames.ModelCompossibleErrorName);
        }

        private bool VerifyCredentials(LoginDoctorCommand login)
        {
            var doctor = _context.Doctors.GetSingleBySpec(new DoctorWithUserPropsSpecifications(login.Username));

            return doctor == null ? false : _securePasswordHasher.Verify(login.Password, doctor.User.PasswordHash);
        }
    }
}
