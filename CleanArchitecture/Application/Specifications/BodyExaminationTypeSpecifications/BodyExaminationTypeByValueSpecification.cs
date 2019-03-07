using System;
using System.Linq.Expressions;
using Domain.Entities.BodyExaminationResultAggregate;
using Domain.Enums;

namespace Application.Specifications.BodyExaminationTypeSpecifications
{
    public class BodyExaminationTypeByValueSpecification : BaseSpecification<Domain.Entities.BodyExaminationResultAggregate.BodyExaminationType>
    {
        public BodyExaminationTypeByValueSpecification(Domain.Enums.BodyExaminationType? type) 
            : base(b => b.Value == type.Value)
        {
        }
    }
}
