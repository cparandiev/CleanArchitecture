using Application.Features.Clinic.Models;
using Application.Features.Doctor.Models;
using Application.Features.MedicalExaminationRequest.Models;
using Application.Features.MedicalExaminationResult.Models;
using Application.Features.Patient.Models;
using Application.Features.Users.Models;
using AutoMapper;
using Domain.Enums;
using System.Linq;
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

            CreateMap<PatientDto, LoggedPatientViewModel>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username))
                .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.User.Roles.Where(r => r == Role.Patient.ToString())))
                .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.Id));

            #endregion

            #region Doctor mappings
            CreateMap<DoctorDto, DoctorViewModel>();

            CreateMap<DoctorDto, LoggedDoctorViewModel>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username))
                .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.User.Roles.Where(r => r == Role.Doctor.ToString())))
                .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.Id));
            #endregion

            #region Clinic mappings
            CreateMap<ClinicDto, ClinicViewModel>();
            #endregion


            #region Medical Examination mappings
            CreateMap<MedicalExaminationRequestDto, MedicalExaminationRequestViewModel>();
            CreateMap<MedicalExaminationResultDto, MedicalExaminationResultViewModel>();
            #endregion
        }
    }
}
