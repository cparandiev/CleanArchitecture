using Microsoft.AspNetCore.Mvc;

namespace Web.Models.BindingModels
{
    public class DoctorWorkingTimesBm
    {
        [FromRoute]
        public int? DoctorId { get; set; }
    }
}
