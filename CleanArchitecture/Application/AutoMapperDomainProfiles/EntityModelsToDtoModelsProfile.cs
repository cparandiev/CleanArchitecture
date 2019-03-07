using Application.AutoMapperDomainProfiles.Converters;
using Application.Features.BodyЕxamination.Models;
using Application.Features.Clinic.Models;
using Application.Features.Doctor.Models;
using Application.Features.MedicalExaminationRequest.Models;
using Application.Features.MedicalExaminationResult.Models;
using Application.Features.Patient.Models;
using Application.Features.Users.Models;
using AutoMapper;
using Domain.Entities.BodyЕxaminationResultAggregate;
using Domain.Entities.ClinicAggregate;
using Domain.Entities.DoctorAggregate;
using Domain.Entities.MedicalExaminationRequestAggregate;
using Domain.Entities.MedicalExaminationResultAggregate;
using Domain.Entities.PatientAggregate;
using Domain.Entities.UserAggregate;
using Domain.Enums;
using System;
using System.Linq;

namespace Application.AutoMapperDomainProfiles
{
    public class EntityModelsToDtoModelsProfile : Profile
    {
        public EntityModelsToDtoModelsProfile()
        {
            #region User mappings
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.UserRoles.Select(ur => ur.Role.Value)));
            #endregion

            #region Patient mappings
            CreateMap<Patient, PatientDto>();
            #endregion

            #region Doctor mappings
            CreateMap<Doctor, DoctorDto>();

            CreateMap<DoctorWorkingTime, DoctorWorkingTimeDto>();
            #endregion

            #region Medical Examination mappings
            CreateMap<MedicalExaminationRequest, MedicalExaminationRequestDto>()
                .ForMember(dest => dest.Doctor, opt => opt.MapFrom(src => $"{src.Doctor.User.FirstName} {src.Doctor.User.LastName}"))
                .ForMember(dest => dest.Patient, opt => opt.MapFrom(src => $"{src.Patient.User.FirstName} {src.Patient.User.LastName}"))
                .ForMember(dest => dest.Clinic, opt => opt.MapFrom(src => src.Doctor.Clinic.Name));

            CreateMap<MedicalExaminationResult, MedicalExaminationResultDto>();
            #endregion

            #region Clinic mappings
            CreateMap<Clinic, ClinicDto>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => $"{src.Address.Country}-{src.Address.City}-{src.Address.Street}"));
            #endregion

            #region Body Examination mappings
            CreateMap<BodyЕxaminationResult, BodyЕxaminationResultDto>();

            CreateMap<BodyЕxaminationResultType, string>()
                .ConvertUsing(src => Enum.GetName((src.Type.Value.GetType()), src.Type.Value) ?? string.Empty);

            CreateMap<BloodOxygenLevelExamination, BodyЕxaminationResultDto>();
            CreateMap<BloodPressureExamination, BloodPressureExaminationDto>();
            CreateMap<BodyTemperatureExamination, BodyTemperatureExaminationDto>();
            CreateMap<PulseRateExamination, PulseRateExaminationDto>();
            #endregion

            CreateMap<Blood, string>()
                .ConvertUsing<EnumToStringConverter<Blood>>();

            CreateMap<Gender, string>()
                .ConvertUsing<EnumToStringConverter<Gender>>();

            CreateMap<Domain.Enums.Role, string>()
                .ConvertUsing<EnumToStringConverter<Domain.Enums.Role>>();

            CreateMap<BodyExaminationType, string>()
                .ConvertUsing<EnumToStringConverter<BodyExaminationType>>();
        }
    }
}
