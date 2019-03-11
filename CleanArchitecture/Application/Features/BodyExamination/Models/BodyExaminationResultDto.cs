using System;
using System.Collections.Generic;

namespace Application.Features.BodyExamination.Models
{
    public class BodyExaminationResultDto
    {
        public BodyExaminationResultDto()
        {
            BodyExaminationResultTypes = new HashSet<string>();
        }

        public int? Id { get; set; }

        public int PatientId { get; set; }

        public string Patient { get; set; }

        public DateTime? ExaminationDate  { get; set; }

        public BloodOxygenLevelExaminationDto BloodOxygenLevel { get; set; }

        public BloodPressureExaminationDto BloodPressure { get; set; }

        public BodyTemperatureExaminationDto BodyTemperature { get; set; }

        public PulseRateExaminationDto PulseRate { get; set; }

        public ICollection<string> BodyExaminationResultTypes { get; set; }
    }
}
