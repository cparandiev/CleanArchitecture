using Application.Constants.User.Validation;
using Application.Interfaces;
using FluentValidation.Validators;

namespace Application.Helpers.FluentValidators
{
    public class UserExistsValidator<T> : PropertyValidator
    {
        private readonly IUnitOfWork _context;

        public UserExistsValidator(IUnitOfWork context) 
            : base(ErrorMessages.USER_NOT_FOUND)
        {
            _context = context;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            int userId = (int)context.PropertyValue;
            return _context.Users.GetById(userId) != null;
        }
    }
}
