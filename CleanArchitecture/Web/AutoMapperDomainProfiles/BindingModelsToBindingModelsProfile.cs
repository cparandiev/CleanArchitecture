using AutoMapper;
using Web.Models.BindingModels;

namespace Web.AutoMapperDomainProfiles
{
    public class BindingModelsToBindingModelsProfile : Profile
    {
        public BindingModelsToBindingModelsProfile()
        {
            CreateMap<RegisterPatientBm, LoginPatientBm>();
            CreateMap<RegisterDoctorBm, LoginDoctorBm>();
        }
    }
}
