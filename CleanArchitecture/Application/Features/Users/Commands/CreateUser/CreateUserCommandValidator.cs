using Application.Interfaces;
using Application.Specifications.UserSpecifications;
using FluentValidation;

namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IUnitOfWork _context;

        public CreateUserCommandValidator(IUnitOfWork context)
        {
            _context = context;

            RuleFor(x => x.Username)
                .MinimumLength(3)
                .MaximumLength(10)
                .NotNull();

            RuleFor(x => x.Username)
                .Must(UniqueName)
                .WithMessage("Username must be unique.");
        }

        private bool UniqueName(string name)
        {
            return _context.Users.Count(new UserWithUsernameSpecification(name)) == 0;
        }
    }
}
