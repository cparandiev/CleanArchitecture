using Application.Features.Patient.Models;
using Application.Features.Users.Models;
using AutoMapper;
using Web.Models.ViewModels;

namespace Web.AutoMapperDomainProfiles
{
    public class DtoModelsToViewModelsProfile : Profile
    {
        public DtoModelsToViewModelsProfile()
        {
            CreateMap<UserDto, UserViewModel>();
            CreateMap<PatientDto, PatientViewModel>();
        }
    }
}
