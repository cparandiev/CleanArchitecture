using System.Collections.Generic;

namespace Web.Models.ViewModels
{
    public class DoctorViewModel
    {
        public int Id { get; set; }

        public int ClinicId { get; set; }

        public string Summary { get; set; }

        public UserViewModel User { get; set; }
    }
}
