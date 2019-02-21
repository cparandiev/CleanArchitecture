using System.Collections.Generic;

namespace Web.Models.ViewModels
{
    public class ClinicViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public List<DoctorViewModel> Doctors { get; set; }
    }
}
