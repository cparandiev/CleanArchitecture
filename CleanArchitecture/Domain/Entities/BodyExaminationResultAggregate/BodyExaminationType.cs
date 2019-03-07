using System.Collections.Generic;

namespace Domain.Entities.BodyExaminationResultAggregate
{
    public class BodyExaminationType : BaseEntity
    {
        public BodyExaminationType()
        {
            BodyExaminationResultTypes = new HashSet<BodyExaminationResultType>();
        }

        public Enums.BodyExaminationType? Value { get; set; }

        public ICollection<BodyExaminationResultType> BodyExaminationResultTypes { get; set; }
    }
}
