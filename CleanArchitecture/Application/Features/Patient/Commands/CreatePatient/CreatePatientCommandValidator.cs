using Application.Constants.User.Validation;
using Application.Interfaces;
using FluentValidation;

namespace Application.Features.Patient.Commands.CreatePatient
{
    public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
    {
        private readonly IUnitOfWork _context;

        public CreatePatientCommandValidator(IUnitOfWork context)
        {
            _context = context;

            RuleFor(x => x.UserId)
                .Must(UserExists)
                .WithMessage(ErrorMessages.USER_NOT_FOUND);
        }

        private bool UserExists(int userId)
        {
            return _context.Users.GetById(userId) != null; 
        }
    }
}
