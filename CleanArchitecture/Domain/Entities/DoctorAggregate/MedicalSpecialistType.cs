using System.Collections.Generic;

namespace Domain.Entities.DoctorAggregate
{
    public class MedicalSpecialistType : BaseEntity
    {
        public MedicalSpecialistType()
        {
            DoctorMedicalSpecialistTypes = new HashSet<DoctorMedicalSpecialistType>();
        }
        public Enums.MedicalSpecialistType? Value { get; set; }

        public virtual IEnumerable<DoctorMedicalSpecialistType> DoctorMedicalSpecialistTypes { get; set; }
    }
}
