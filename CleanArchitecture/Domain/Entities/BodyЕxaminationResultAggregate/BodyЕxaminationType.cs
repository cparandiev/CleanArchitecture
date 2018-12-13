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

        public IEnumerable<BodyЕxaminationResultType> BodyЕxaminationResultTypes { get; set; }
    }
}
