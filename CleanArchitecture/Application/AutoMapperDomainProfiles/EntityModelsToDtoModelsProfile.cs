using Application.AutoMapperDomainProfiles.Converters;
using Application.Features.Doctor.Models;
using Application.Features.Patient.Models;
using Application.Features.Users.Models;
using AutoMapper;
using Domain.Entities.DoctorAggregate;
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
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.UserRoles.Select(ur => ur.Role.Value)));

            CreateMap<Patient, PatientDto>();

            CreateMap<Doctor, DoctorDto>();

            CreateMap<Blood, string>()
                .ConvertUsing<EnumToStringConverter<Blood>>();

            CreateMap<Gender, string>()
                .ConvertUsing<EnumToStringConverter<Gender>>();

            CreateMap<Domain.Enums.Role, string>()
                .ConvertUsing<EnumToStringConverter<Domain.Enums.Role>>();
        }
    }
}
