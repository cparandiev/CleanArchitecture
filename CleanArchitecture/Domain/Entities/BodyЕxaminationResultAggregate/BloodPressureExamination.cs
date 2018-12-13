namespace Domain.Entities.BodyЕxaminationResultAggregate
{
    public class BloodPressureExamination : BaseEntity
    {
        public decimal? SystolicBloodPressure { get; set; }

        public decimal? DiastolicBloodPressure { get; set; }

        public int ResultId { get; set; }

        public virtual BodyЕxaminationResult Result { get; set; }
    }
}
