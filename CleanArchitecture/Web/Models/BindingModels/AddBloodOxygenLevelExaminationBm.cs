using System;

namespace Web.Models.BindingModels
{
    public class AddBloodOxygenLevelExaminationBm
    {
        public int? PatientId { get; set; }

        public DateTime? ExaminationDate { get; set; }

        public decimal? OxygenLevel { get; set; }
    }
}
