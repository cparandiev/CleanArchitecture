using Domain.Entities.MedicalExaminationRequestAggregate;

namespace Domain.Entities.MedicalExaminationResultAggregate
{
    public class MedicalExaminationResult : BaseEntity
    {
        public string Notes { get; set; }

        public int RequestId { get; set; }

        public virtual MedicalExaminationRequest Request { get; set; }
    }
}
