namespace Domain.Entities.BodyЕxaminationResultAggregate
{
    public class BodyTemperatureExamination : BaseEntity
    {
        public decimal? Temperature { get; set; }

        public int ResultId { get; set; }

        public virtual BodyЕxaminationResult Result { get; set; }
    }
}
