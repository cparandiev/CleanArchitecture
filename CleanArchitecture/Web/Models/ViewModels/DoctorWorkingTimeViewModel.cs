using System;

namespace Web.Models.ViewModels
{
    public class DoctorWorkingTimeViewModel
    {
        public int? Id { get; set; }

        public int? DoctorId { get; set; }

        public DateTime? Open { get; set; }

        public DateTime? Close { get; set; }
    }
}
