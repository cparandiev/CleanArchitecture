namespace Domain.Entities.BodyExaminationResultAggregate
{
    public class BloodOxygenLevelExamination : BaseEntity
    {
        public decimal? OxygenLevel { get; set; }

        public int ResultId { get; set; }

        public virtual BodyExaminationResult Result { get; set; }
    }
}
