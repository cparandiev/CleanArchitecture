using Domain.Entities.BodyЕxaminationResultAggregate;
using Domain.Entities.MedicalExaminationRequestAggregate;
using Domain.Entities.UserAggregate;
using System.Collections.Generic;

namespace Domain.Entities.PatientAggregate
{
    public class Patient : BaseEntity
    {
        public Patient()
        {
            BodyЕxaminationResults = new HashSet<BodyЕxaminationResult>();
            MedicalExaminationRequests = new HashSet<MedicalExaminationRequest>();
        }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual IEnumerable<MedicalExaminationRequest> MedicalExaminationRequests { get; set; }

        public virtual IEnumerable<BodyЕxaminationResult> BodyЕxaminationResults { get; set; }
    }
}
