using Application.AutoMapperDomainProfiles.Converters;
using Application.Features.Patient.Models;
using Application.Features.Users.Models;
using AutoMapper;
using Domain.Entities.PatientAggregate;
using Domain.Entities.UserAggregate;
using Domain.Enums;
using System;

namespace Application.AutoMapperDomainProfiles
{
    public class EntityModelsToDtoModelsProfile : Profile
    {
        public EntityModelsToDtoModelsProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<User, PatientDto>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.UserRoles));

            CreateMap<Blood, string>()
                .ConvertUsing<EnumToStringConverter<Blood>>();

            CreateMap<Gender, string>()
                .ConvertUsing<EnumToStringConverter<Gender>>();

            CreateMap<Domain.Enums.Role, string>()
                .ConvertUsing<EnumToStringConverter<Domain.Enums.Role>>();

            CreateMap<Patient, PatientDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.User.Id))
                .ConvertUsing(s => Mapper.Map<User, PatientDto>(s.User)); // todo

        }
    }
}
