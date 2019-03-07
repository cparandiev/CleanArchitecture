using Domain.Entities.PatientAggregate;
using System;
using System.Collections.Generic;

namespace Domain.Entities.BodyExaminationResultAggregate
{
    public class BodyExaminationResult : BaseEntity
    {
        public BodyExaminationResult()
        {
            BodyExaminationResultTypes = new HashSet<BodyExaminationResultType>();
        }

        public int PatientId { get; set; }

        public DateTime? ExaminationDate  { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual BloodOxygenLevelExamination BloodOxygenLevel { get; set; }

        public virtual BloodPressureExamination BloodPressure { get; set; }

        public virtual BodyTemperatureExamination BodyTemperature { get; set; }

        public virtual PulseRateExamination PulseRate { get; set; }

        public virtual ICollection<BodyExaminationResultType> BodyExaminationResultTypes { get; set; }

    }
}
