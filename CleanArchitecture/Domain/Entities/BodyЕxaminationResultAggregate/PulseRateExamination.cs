namespace Domain.Entities.BodyЕxaminationResultAggregate
{
    public class PulseRateExamination : BaseEntity
    {
        public decimal? Rate { get; set; }

        public int ResultId { get; set; }

        public virtual BodyЕxaminationResult Result { get; set; }
    }
}
