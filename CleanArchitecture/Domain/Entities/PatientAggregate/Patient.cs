using Domain.Entities.BodyExaminationResultAggregate;
using Domain.Entities.MedicalExaminationRequestAggregate;
using Domain.Entities.UserAggregate;
using System.Collections.Generic;

namespace Domain.Entities.PatientAggregate
{
    public class Patient : BaseEntity
    {
        public Patient()
        {
            BodyExaminationResults = new HashSet<BodyExaminationResult>();
            MedicalExaminationRequests = new HashSet<MedicalExaminationRequest>();
        }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<MedicalExaminationRequest> MedicalExaminationRequests { get; set; }

        public virtual ICollection<BodyExaminationResult> BodyExaminationResults { get; set; }
    }
}
