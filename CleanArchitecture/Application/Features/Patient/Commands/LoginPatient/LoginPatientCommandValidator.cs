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
                .NotEmpty();

            RuleFor(x => x.Password)
                .NotEmpty();

            RuleFor(x => x)
                .Must(VerifyCredentials)
                .WithMessage("Wrong username or password.")
                .OverridePropertyName("global");
        }

        private bool VerifyCredentials(LoginPatientCommand login)
        {
            var paitent = _context.Patients.GetSingleBySpec(new PatientWithUserPropsSpecifications(login.Username));

            return paitent == null ? false : _securePasswordHasher.Verify(login.Password, paitent.User.PasswordHash);
        }
    }
}
