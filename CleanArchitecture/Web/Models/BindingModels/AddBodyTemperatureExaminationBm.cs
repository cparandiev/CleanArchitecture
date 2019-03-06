using System;

namespace Web.Models.BindingModels
{
    public class AddBodyTemperatureExaminationBm
    {
        public int? PatientId { get; set; }

        public DateTime? ЕxaminationDate { get; set; }

        public decimal? Temperature { get; set; }
    }
}
