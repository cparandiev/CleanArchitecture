using System;

namespace Web.Models.BindingModels
{
    public class AddPulseRateExaminationBm
    {
        public int? PatientId { get; set; }

        public DateTime? ExaminationDate { get; set; }

        public decimal? Rate { get; set; }
    }
}
