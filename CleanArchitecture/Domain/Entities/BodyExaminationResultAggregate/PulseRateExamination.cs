namespace Domain.Entities.BodyExaminationResultAggregate
{
    public class PulseRateExamination : BaseEntity
    {
        public decimal? Rate { get; set; }

        public int ResultId { get; set; }

        public virtual BodyExaminationResult Result { get; set; }
    }
}
