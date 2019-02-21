using Microsoft.AspNetCore.Mvc;

namespace Web.Models.BindingModels
{
    public class PatientMedicalExaminationsBm
    {
        [FromRoute]
        public int? PatientId { get; set; }
    }
}
