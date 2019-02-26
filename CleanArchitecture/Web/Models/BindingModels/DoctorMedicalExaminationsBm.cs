using Microsoft.AspNetCore.Mvc;

namespace Web.Models.BindingModels
{
    public class DoctorMedicalExaminationsBm
    {
        [FromRoute]
        public int? DoctorId { get; set; }
    }
}
