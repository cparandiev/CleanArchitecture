namespace Domain.Entities.BodyExaminationResultAggregate
{
    public class BodyExaminationResultType
    {
        public int BodyExaminationResultId { get; set; }
        public virtual BodyExaminationResult Result { get; set; }
        public int BodyExaminationTypeId { get; set; }
        public virtual BodyExaminationType Type { get; set; }
    }
}
