using System;

namespace Web.Models.BindingModels
{
    public class AddBodyTemperatureExaminationBm
    {
        public int? PatientId { get; set; }

        public DateTime? ExaminationDate { get; set; }

        public decimal? Temperature { get; set; }
    }
}
