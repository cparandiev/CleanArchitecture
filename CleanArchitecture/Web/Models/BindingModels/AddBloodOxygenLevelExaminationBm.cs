using System;

namespace Web.Models.BindingModels
{
    public class AddBloodOxygenLevelExaminationBm
    {
        public int? PatientId { get; set; }

        public DateTime? ЕxaminationDate { get; set; }

        public decimal? OxygenLevel { get; set; }
    }
}
