using Application.Interfaces;
using FluentValidation;
using Application.Features.Users.Commands.CreateUser;

namespace Application.Features.Patient.Commands.CreatePatient
{
    public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientCommandValidator(IUnitOfWork context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.CreateUserCommand)
                .SetValidator(new CreateUserCommandValidator(context));
        }
    }
}
