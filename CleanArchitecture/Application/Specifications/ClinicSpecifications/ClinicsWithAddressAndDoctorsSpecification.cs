using Domain.Entities.ClinicAggregate;
using Domain.Entities.DoctorAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Specifications.ClinicSpecifications
{
    public class ClinicsWithAddressAndDoctorsSpecification : BaseSpecification<Clinic>
    {
        public ClinicsWithAddressAndDoctorsSpecification()
            : base(c => true)
        {
            AddIncludes();
        }

        private void AddIncludes()
        {
            AddInclude(c => c.Address);
            AddInclude(c => c.Doctors);
            AddInclude($"{nameof(Clinic.Doctors)}.{nameof(Doctor.User)}");
            AddInclude($"{nameof(Clinic.Doctors)}.{nameof(Doctor.WorkingTimes)}");
        }
    }
}
