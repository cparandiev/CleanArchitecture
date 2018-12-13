namespace Domain.Entities.BodyЕxaminationResultAggregate
{
    public class BloodOxygenLevelExamination : BaseEntity
    {
        public decimal? OxygenLevel { get; set; }

        public int ResultId { get; set; }

        public virtual BodyЕxaminationResult Result { get; set; }
    }
}
