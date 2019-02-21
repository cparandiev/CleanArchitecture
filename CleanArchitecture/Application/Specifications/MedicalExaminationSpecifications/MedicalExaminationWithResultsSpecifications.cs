using Domain.Entities.DoctorAggregate;
using Domain.Entities.MedicalExaminationRequestAggregate;
using Domain.Entities.PatientAggregate;

namespace Application.Specifications.MedicalExaminationSpecifications
{
    public class MedicalExaminationWithResultsSpecifications : BaseSpecification<MedicalExaminationRequest>
    {
        public MedicalExaminationWithResultsSpecifications(int? patientId)
            : base(m => m.PatientId == patientId.Value)
        {
            AddIncludes();
        }

        private void AddIncludes()
        {
            AddInclude(m => m.Result);
            AddInclude($"{nameof(MedicalExaminationRequest.Doctor)}.{nameof(Doctor.User)}");
            AddInclude($"{nameof(MedicalExaminationRequest.Doctor)}.{nameof(Doctor.Clinic)}");
            AddInclude($"{nameof(MedicalExaminationRequest.Patient)}.{nameof(Patient.User)}");
        }
    }
}
