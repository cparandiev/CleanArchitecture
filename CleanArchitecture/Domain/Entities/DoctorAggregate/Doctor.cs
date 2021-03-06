﻿using Domain.Entities.ClinicAggregate;
using Domain.Entities.MedicalExaminationRequestAggregate;
using Domain.Entities.UserAggregate;
using System.Collections.Generic;

namespace Domain.Entities.DoctorAggregate
{
    public class Doctor : BaseEntity
    {
        public Doctor()
        {
            WorkingTimes = new HashSet<DoctorWorkingTime>();
            MedicalExaminationRequests = new HashSet<MedicalExaminationRequest>();
            DoctorMedicalSpecialistTypes = new HashSet<DoctorMedicalSpecialistType>();
        }

        public string Summary { get; set; }

        public int UserId { get; set; }

        public int ClinicId { get; set; }

        public virtual User User { get; set; }

        public virtual Clinic Clinic { get; set; }

        public virtual ICollection<DoctorWorkingTime> WorkingTimes { get; set; }

        public virtual ICollection<MedicalExaminationRequest> MedicalExaminationRequests { get; set; }

        public virtual ICollection<DoctorMedicalSpecialistType> DoctorMedicalSpecialistTypes { get; set; }
    }
}
