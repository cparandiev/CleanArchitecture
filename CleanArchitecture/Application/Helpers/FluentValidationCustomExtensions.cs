using Application.Helpers.FluentValidators;
using FluentValidation;
using System;

namespace Application.Helpers
{
    public static class FluentValidationCustomExtensions
    {
        public static IRuleBuilderOptions<T, TElement> IsValidEnum<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder, Type enumType)
        {
            return ruleBuilder.SetValidator(new IsValidEnumValidator<TElement>(enumType));
        }
    }
}
