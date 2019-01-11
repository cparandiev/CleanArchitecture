using System;

namespace Web.Models.BindingModels
{
    public class RequestMedicalExaminationBm
    {
        public DateTime? RequestDate { get; set; }

        public int? DurationInMinutes { get; set; }

        public int? DoctorId { get; set; }

        public int? PatientId { get; set; }
    }
}
