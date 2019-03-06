using System;

namespace Web.Models.BindingModels
{
    public class AddPulseRateExaminationBm
    {
        public int? PatientId { get; set; }

        public DateTime? ЕxaminationDate { get; set; }

        public decimal? Rate { get; set; }
    }
}
