using Domain.Entities.DoctorAggregate;
using Domain.Entities.MedicalExaminationResultAggregate;
using Domain.Entities.PatientAggregate;
using System;

namespace Domain.Entities.MedicalExaminationRequestAggregate
{
    public class MedicalExaminationRequest : BaseEntity
    {
        public bool? IsApproved { get; set; }

        public bool? IsAccomplished { get; set; }

        public DateTime? RequestDate { get; set; }

        public int? DurationInMinutes { get; set; }

        public int? DoctorId { get; set; }

        public int? PatientId { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual MedicalExaminationResult Result { get; set; }
    }
}
