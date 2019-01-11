using Application.Helpers;
using Application.Interfaces;
using Application.Constants.User.Validation;
using FluentValidation;

namespace Application.Features.Patient.Commands.CreatePatient
{
    public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientCommandValidator(IUnitOfWork context)
        {
            RuleFor(x => x.UserId)
                .NotNull()
                //.Any(context.Users, prop => entity => entity.Id == prop.Value, ErrorMessages.USER_NOT_FOUND);
                .UserExists(context);
        }
    }
}
