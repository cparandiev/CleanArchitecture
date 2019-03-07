using System;

namespace Web.Models.BindingModels
{
    public class AddBloodPressureExaminationBm
    {
        public int? PatientId { get; set; }

        public DateTime? ЕxaminationDate { get; set; }

        public decimal? SystolicBloodPressure { get; set; }

        public decimal? DiastolicBloodPressure { get; set; }
    }
}
