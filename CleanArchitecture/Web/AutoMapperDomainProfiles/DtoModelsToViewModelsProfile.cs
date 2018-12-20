using Application.Features.Doctor.Models;
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
            #region User mappings
            CreateMap<UserDto, UserViewModel>();
            #endregion

            #region Patient mappings
            CreateMap<PatientDto, PatientViewModel>();

            CreateMap<PatientDto, LoggedUserViewModel>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username))
                .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.User.Roles));
            #endregion

            #region Doctor mappings
            CreateMap<DoctorDto, LoggedUserViewModel>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username))
                .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.User.Roles));
            #endregion
        }
    }
}
