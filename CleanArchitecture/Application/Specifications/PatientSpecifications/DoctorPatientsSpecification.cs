using System.Linq;
using Domain.Entities.MedicalExaminationRequestAggregate;
using Domain.Entities.PatientAggregate;

namespace Application.Specifications.PatientSpecifications
{
    public class DoctorPatientsSpecification : BaseSpecification<Patient>
    {
        public DoctorPatientsSpecification(int doctorId)
            : base(p => p.MedicalExaminationRequests.Any(m => m.DoctorId == doctorId))
        {
            AddIncludes();
        }

        private void AddIncludes()
        {
            AddInclude(u => u.User);
            AddInclude($"{nameof(Patient.MedicalExaminationRequests)}.{nameof(MedicalExaminationRequest.Doctor)}");
        }
    }
}
