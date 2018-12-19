using Application.Helpers;
using Application.Interfaces;
using FluentValidation;

namespace Application.Features.Patient.Commands.CreatePatient
{
    public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientCommandValidator(IUnitOfWork context)
        {
            RuleFor(x => x.UserId)
                .NotNull()
                .UserExists(context);
        }
    }
}
