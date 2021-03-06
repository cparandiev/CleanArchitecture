﻿namespace Domain.Entities.BodyExaminationResultAggregate
{
    public class BodyTemperatureExamination : BaseEntity
    {
        public decimal? Temperature { get; set; }

        public int ResultId { get; set; }

        public virtual BodyExaminationResult Result { get; set; }
    }
}
