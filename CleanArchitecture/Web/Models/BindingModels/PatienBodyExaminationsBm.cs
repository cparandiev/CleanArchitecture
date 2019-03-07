using Microsoft.AspNetCore.Mvc;

namespace Web.Models.BindingModels
{
    public class PatienBodyExaminationsBm
    {
        [FromRoute]
        public int? PatientId { get; set; }
    }
}
