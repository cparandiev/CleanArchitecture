using Application.Features.Users.Models;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using System;

namespace Application.AutoMapperDomainProfiles
{
    public class EntityModelsToDtoModelsProfile : Profile
    {
        public EntityModelsToDtoModelsProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Role, RoleDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => Enum.GetName((src.GetType()), src)));
        }
    }
}
