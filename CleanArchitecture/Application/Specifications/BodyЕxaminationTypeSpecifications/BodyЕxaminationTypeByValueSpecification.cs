using System;
using System.Linq.Expressions;
using Domain.Entities.BodyЕxaminationResultAggregate;
using Domain.Enums;

namespace Application.Specifications.BodyЕxaminationTypeSpecifications
{
    public class BodyЕxaminationTypeByValueSpecification : BaseSpecification<BodyЕxaminationType>
    {
        public BodyЕxaminationTypeByValueSpecification(BodyExaminationType? type) 
            : base(b => b.Value == type.Value)
        {
        }
    }
}
