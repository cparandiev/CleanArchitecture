using Domain.Entities.BodyExaminationResultAggregate;

namespace Application.Specifications.BodyExaminationResultSpecifications
{
    public class PatientBodyExaminationResultSpecification : BaseSpecification<BodyExaminationResult>
    {
        public PatientBodyExaminationResultSpecification(int? patientId) 
            : base(be => be.PatientId == patientId.Value)
        {
            AddIncludes();
        }

        private void AddIncludes()
        {
            AddInclude(m => m.BloodOxygenLevel);
            AddInclude(m => m.BloodPressure);
            AddInclude(m => m.BodyTemperature);
            AddInclude(m => m.PulseRate);
            AddInclude(m => m.Patient);
            AddInclude($"{nameof(BodyExaminationResult.BodyExaminationResultTypes)}.{nameof(BodyExaminationResultType.Type)}");
        }

    }
}
