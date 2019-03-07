using System;
using System.Collections.Generic;

namespace Application.Features.BodyЕxamination.Models
{
    public class BodyЕxaminationResultDto
    {
        public BodyЕxaminationResultDto()
        {
            BodyЕxaminationResultTypes = new HashSet<string>();
        }

        public int PatientId { get; set; }

        public DateTime? ЕxaminationDate  { get; set; }

        public BloodOxygenLevelExaminationDto BloodOxygenLevel { get; set; }

        public BloodPressureExaminationDto BloodPressure { get; set; }

        public BodyTemperatureExaminationDto BodyTemperature { get; set; }

        public PulseRateExaminationDto PulseRate { get; set; }

        public ICollection<string> BodyЕxaminationResultTypes { get; set; }
    }
}
