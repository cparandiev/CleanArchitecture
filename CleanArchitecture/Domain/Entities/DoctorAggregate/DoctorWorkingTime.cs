using Domain.ValueObjects;
using System;

namespace Domain.Entities.DoctorAggregate
{
    public class DoctorWorkingTime : BaseEntity
    {
        public int DoctorId { get; set; }

        public DateTime? Open { get; set; }

        public DateTime? Close { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
