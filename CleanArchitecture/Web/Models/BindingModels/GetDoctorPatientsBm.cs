using Microsoft.AspNetCore.Mvc;

namespace Web.Models.BindingModels
{
    public class GetDoctorPatientsBm
    {
        [FromRoute]
        public int? DoctorId { get; set; }
    }
}
