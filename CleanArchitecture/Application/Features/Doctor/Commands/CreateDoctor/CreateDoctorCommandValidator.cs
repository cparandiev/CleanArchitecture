using Application.Constants.User.Validation;
using Application.Interfaces;
using FluentValidation;

namespace Application.Features.Doctor.Commands.CreateDoctor
{
    public class CreateDoctorCommandValidator : AbstractValidator<CreateDoctorCommand>
    {
        private readonly IUnitOfWork _context;

        public CreateDoctorCommandValidator(IUnitOfWork context)
        {
            _context = context;

            RuleFor(x => x.UserId)
                .Must(UserExists)
                .WithMessage(ErrorMessages.USER_NOT_FOUND);

            RuleFor(x => x.Summary)
                .NotNull()
                .MinimumLength(Constants.Doctor.Validation.ValidationParameters.SUMMARY_MIN_LENGTH)
                .MaximumLength(Constants.Doctor.Validation.ValidationParameters.SUMMARY_MAX_LENGTH);
        }

        private bool UserExists(int userId)
        {
            return _context.Users.GetById(userId) != null;
        }

        private bool ClinicExists(int clinicId)
        {
            return _context.Clinics.GetById(clinicId) != null;
        }
    }
}
