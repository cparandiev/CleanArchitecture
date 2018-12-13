namespace Domain.Entities.BodyЕxaminationResultAggregate
{
    public class BodyЕxaminationResultType
    {
        public int BodyЕxaminationResultId { get; set; }
        public virtual BodyЕxaminationResult Result { get; set; }
        public int BodyЕxaminationTypeId { get; set; }
        public virtual BodyЕxaminationType Type { get; set; }
    }
}
