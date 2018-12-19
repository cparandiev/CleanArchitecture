using System;

namespace Web.Models.BindingModels
{
    public class RegisterDoctorBm
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime Birthdate { get; set; }

        public string Gender { get; set; }

        public decimal Height { get; set; }

        public decimal Weight { get; set; }

        public string Blood { get; set; }

        public string Summary { get; set; }

        public int? ClinicId { get; set; }
    }
}
