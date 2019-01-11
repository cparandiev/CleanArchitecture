using Application.Helpers.FluentValidators;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Domain.Entities.UserAggregate;
using FluentValidation;
using System;
using System.Linq.Expressions;

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

        public static IRuleBuilderOptions<T, TElement> PatientExists<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder, IUnitOfWork context)
        {
            return ruleBuilder.SetValidator(new PatientExistsValidator<TElement>(context));
        }

        public static IRuleBuilderOptions<T, TElement> MedicalExaminationRequestExists<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder, IUnitOfWork context)
        {
            return ruleBuilder.SetValidator(new MedicalExaminationRequestExistsValidator<TElement>(context));
        }

        public static IRuleBuilderOptions<T, TElement> None<T, TEntity, TElement>(this IRuleBuilder<T, TElement> ruleBuilder, IRepository<TEntity> repository, Func<TElement, Expression<Func<TEntity, bool>>> setUpCriteria, string errorMessage)
            where TEntity : BaseEntity
        {
            return ruleBuilder.SetValidator(new NoneEntitiesValidator<TElement, TEntity>(repository, setUpCriteria, errorMessage));
        }
    }
}
