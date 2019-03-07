using Microsoft.AspNetCore.Mvc;

namespace Web.Models.BindingModels
{
    public class PatienBodyЕxaminationsBm
    {
        [FromRoute]
        public int? PatientId { get; set; }
    }
}
