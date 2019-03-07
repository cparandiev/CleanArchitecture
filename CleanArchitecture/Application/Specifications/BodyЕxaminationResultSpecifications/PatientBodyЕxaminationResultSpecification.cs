using Domain.Entities.BodyЕxaminationResultAggregate;

namespace Application.Specifications.BodyЕxaminationResultSpecifications
{
    public class PatientBodyЕxaminationResultSpecification : BaseSpecification<BodyЕxaminationResult>
    {
        public PatientBodyЕxaminationResultSpecification(int? patientId) 
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
            AddInclude($"{nameof(BodyЕxaminationResult.BodyЕxaminationResultTypes)}.{nameof(BodyЕxaminationResultType.Type)}");
        }

    }
}
