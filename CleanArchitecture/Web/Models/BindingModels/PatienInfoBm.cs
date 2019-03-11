using Microsoft.AspNetCore.Mvc;

namespace Web.Models.BindingModels
{
    public class PatienInfoBm
    {
        [FromRoute]
        public int? PatientId { get; set; }
    }
}
