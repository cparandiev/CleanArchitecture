using Application.Constants.User.Validation;
using Application.Interfaces;
using Application.Specifications.PatientSpecifications;
using FluentValidation;

namespace Application.Features.Patient.Commands.LoginPatient
{
    public class LoginPatientCommandValidator : AbstractValidator<LoginPatientCommand>
    {
        private readonly IUnitOfWork _context;
        private readonly ISecurePasswordHasher _securePasswordHasher;

        public LoginPatientCommandValidator(IUnitOfWork context, ISecurePasswordHasher securePasswordHasher)
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

        private bool VerifyCredentials(LoginPatientCommand login)
        {
            var paitent = _context.Patients.GetSingleBySpec(new PatientWithUserPropsSpecifications(login.Username));

            return paitent == null ? false : _securePasswordHasher.Verify(login.Password, paitent.User.PasswordHash);
        }
    }
}
