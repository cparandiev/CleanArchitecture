using Application.Helpers.FluentValidators;
using Application.Interfaces;
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

        public static IRuleBuilderOptions<T, TElement> UserExists<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder, IUnitOfWork context)
        {
            return ruleBuilder.SetValidator(new UserExistsValidator<TElement>(context));
        }

        public static IRuleBuilderOptions<T, TElement> ClinicExists<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder, IUnitOfWork context)
        {
            return ruleBuilder.SetValidator(new ClinicExistsValidator<TElement>(context));
        }

        public static IRuleBuilderOptions<T, TElement> DoctorExists<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder, IUnitOfWork context)
        {
            return ruleBuilder.SetValidator(new DoctorExistsValidator<TElement>(context));
        }

        public static IRuleBuilderOptions<T, TElement> UniqueUsername<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder, IUnitOfWork context)
        {
            return ruleBuilder.SetValidator(new UniqueUsernameValidator<TElement>(context));
        }
    }
}
