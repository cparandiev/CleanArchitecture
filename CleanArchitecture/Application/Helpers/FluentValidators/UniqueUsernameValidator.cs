using Application.Constants.User.Validation;
using Application.Interfaces;
using Application.Specifications.UserSpecifications;
using FluentValidation.Validators;

namespace Application.Helpers.FluentValidators
{
    public class UniqueUsernameValidator<T> : PropertyValidator
    {
        private readonly IUnitOfWork _context;

        public UniqueUsernameValidator(IUnitOfWork context)
            : base(ErrorMessages.UNIQUE_USERNAME)
        {
            _context = context;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            string username = (string)context.PropertyValue;
            return _context.Users.Count(new UserWithRolesSpecification(username)) == 0;
        }
    }
}
