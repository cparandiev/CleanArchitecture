using Domain.Entities.DoctorAggregate;
using System.Collections.Generic;

namespace Domain.Entities.ClinicAggregate
{
    public class Clinic : BaseEntity
    {
        public Clinic()
        {
            Doctors = new HashSet<Doctor>();
        }

        public string Name { get; set; }
        
        public virtual ClinicAddress Address { get; set; }

        public virtual IEnumerable<Doctor> Doctors { get; set; }
    }
}
