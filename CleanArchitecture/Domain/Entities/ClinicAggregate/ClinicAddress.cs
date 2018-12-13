using Domain.ValueObjects;

namespace Domain.Entities.ClinicAggregate
{
    public class ClinicAddress : Address
    {
        public int ClinicId { get; set; }

        public virtual Clinic Clinic { get; set; }
    }
}
