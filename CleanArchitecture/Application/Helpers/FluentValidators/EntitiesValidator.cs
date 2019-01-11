using Application.Interfaces.Repositories;
using Application.Specifications;
using Domain.Entities;
using FluentValidation.Resources;
using FluentValidation.Validators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Application.Helpers.FluentValidators
{
    public class EntitiesValidator<TElement, TEntity> : PropertyValidator where TEntity : BaseEntity
    {
        private IRepository<TEntity> _repository;
        private Func<TElement, Expression<Func<TEntity, bool>>> _setUpCriteria;
        private Func<IEnumerable<TEntity>, bool> _validation;

        public EntitiesValidator(IRepository<TEntity> repository, Func<TElement, Expression<Func<TEntity, bool>>> setUpCriteria, Func<IEnumerable<TEntity>, bool> validation,string errorMessage) 
            : base(errorMessage)
        {
            _repository = repository;
            _setUpCriteria = setUpCriteria;
            _validation = validation;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var entities = _repository.List(new BaseSpecification<TEntity>(_setUpCriteria((TElement)context.PropertyValue)));

            return _validation(entities);
        }
    }
}
