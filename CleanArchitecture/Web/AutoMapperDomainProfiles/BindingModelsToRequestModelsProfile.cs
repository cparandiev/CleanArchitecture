using Application.AutoMapperDomainProfiles.Converters;
using Application.Features.Doctor.Commands.CreateDoctor;
using Application.Features.Doctor.Commands.SetWeeklyWorkingTime;
using Application.Features.Doctor.Models;
using Application.Features.Patient.Commands.CreatePatient;
using Application.Features.Patient.Commands.LoginPatient;
using Application.Features.Users.Commands.CreateUser;
using AutoMapper;
using Domain.Enums;
using Web.Models.BindingModels;

namespace Web.AutoMapperDomainProfiles
{
    public class BindingModelsToRequestModelsProfile : Profile
    {
        public BindingModelsToRequestModelsProfile()
        {
            #region Patient mappings
            CreateMap<RegisterPatientBm, CreateUserCommand>();
            CreateMap<RegisterPatientBm, CreatePatientCommand>();
            CreateMap<LoginPatientBm, LoginPatientCommand>();
            #endregion

            #region Doctor mappings
            CreateMap<RegisterDoctorBm, CreateUserCommand>();
            CreateMap<RegisterDoctorBm, CreatePatientCommand>();
            CreateMap<RegisterDoctorBm, CreateDoctorCommand>();
            
            CreateMap<DoctorWeeklyWorkingTimeBm, SetWeeklyWorkingTimeCommand>();
            #endregion

            CreateMap<string, Gender>()
                .ConvertUsing<StringToEnumConverter<Gender>>();

            CreateMap<string, Blood>()
                .ConvertUsing<StringToEnumConverter<Blood>>();

            CreateMap<WorkingTimeBm, WorkingTimeUnit>();
        }
    }
}
