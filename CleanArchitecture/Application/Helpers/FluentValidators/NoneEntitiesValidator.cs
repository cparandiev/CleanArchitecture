using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Helpers.FluentValidators
{
    public class NoneEntitiesValidator<TElement, TEntity> : EntitiesValidator<TElement, TEntity> where TEntity : BaseEntity
    {
        private static readonly Func<IEnumerable<TEntity>, bool> _validation = (entities) => !entities.Any();

        public NoneEntitiesValidator(IRepository<TEntity> repository, Func<TElement, Expression<Func<TEntity, bool>>> setUpCriteria, string errorMessage)
            : base(repository, setUpCriteria, _validation, errorMessage)
        {}
    }
}
