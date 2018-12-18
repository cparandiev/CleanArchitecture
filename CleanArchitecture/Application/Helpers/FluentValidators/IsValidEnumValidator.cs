using FluentValidation.Validators;
using System;

namespace Application.Helpers.FluentValidators
{
    public class IsValidEnumValidator<T> : PropertyValidator
    {
        private Type _type;

        public IsValidEnumValidator(Type type)
            : base("{PropertyName} must be in the range of the valid values [{ValidValues}].")
        {
            if (!type.IsEnum)
            {
                throw new ArgumentException("Type must be an enumerated type");
            }

            _type = type;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if(Array.IndexOf(Enum.GetNames(_type), context.PropertyValue) < 0)
            {
                context.MessageFormatter.AppendArgument("ValidValues", string.Join(", ", Enum.GetNames(_type)));
                return false;
            }

            return true;
        }
    }
}
