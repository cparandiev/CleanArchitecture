using Domain.Entities.PatientAggregate;
using System;
using System.Collections.Generic;

namespace Domain.Entities.BodyЕxaminationResultAggregate
{
    public class BodyЕxaminationResult : BaseEntity
    {
        public BodyЕxaminationResult()
        {
            BodyЕxaminationResultTypes = new HashSet<BodyЕxaminationResultType>();
        }

        public int PatientId { get; set; }

        public DateTime? ЕxaminationDate  { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual BloodOxygenLevelExamination BloodOxygenLevel { get; set; }

        public virtual BloodPressureExamination BloodPressure { get; set; }

        public virtual BodyTemperatureExamination BodyTemperature { get; set; }

        public virtual PulseRateExamination PulseRate { get; set; }

        public virtual IEnumerable<BodyЕxaminationResultType> BodyЕxaminationResultTypes { get; set; }

    }
}
