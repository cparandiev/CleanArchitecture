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

        public virtual ICollection<DoctorMedicalSpecialistType> DoctorMedicalSpecialistTypes { get; set; }
    }
}
