using System.Collections.Generic;

namespace Domain.Entities.BodyЕxaminationResultAggregate
{
    public class BodyЕxaminationType : BaseEntity
    {
        public BodyЕxaminationType()
        {
            BodyЕxaminationResultTypes = new HashSet<BodyЕxaminationResultType>();
        }

        public Enums.BodyExaminationType? Value { get; set; }

        public ICollection<BodyЕxaminationResultType> BodyЕxaminationResultTypes { get; set; }
    }
}
