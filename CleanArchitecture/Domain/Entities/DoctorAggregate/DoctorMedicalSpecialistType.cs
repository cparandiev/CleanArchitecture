namespace Domain.Entities.DoctorAggregate
{
    public class DoctorMedicalSpecialistType
    {
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public int MedicalSpecialistTypeId { get; set; }
        public virtual MedicalSpecialistType Type { get; set; }
    }
}
